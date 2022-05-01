﻿using FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FantasyManager.WPF.Common.Behaviors.DragDrop
{
    public class FrameworkElementDropBehavior : Behavior<FrameworkElement>
    {
        private Type dataType; //the type of the data that can be dropped into this control
        private FrameworkElementAdorner adorner;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.AllowDrop = true;
            AssociatedObject.DragEnter += new DragEventHandler(AssociatedObject_DragEnter);
            AssociatedObject.DragOver += new DragEventHandler(AssociatedObject_DragOver);
            AssociatedObject.DragLeave += new DragEventHandler(AssociatedObject_DragLeave);
            AssociatedObject.Drop += new DragEventHandler(AssociatedObject_Drop);
        }

        void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            if (dataType != null)
            {
                //if the data type can be dropped 
                if (e.Data.GetDataPresent(dataType))
                {
                    //drop the data
                    IDropable target = AssociatedObject.DataContext as IDropable;
                    target.Drop(e.Data.GetData(dataType));

                    //remove the data from the source
                    IDragable source = e.Data.GetData(dataType) as IDragable;
                    source.Remove(e.Data.GetData(dataType));
                }
            }
            if (adorner != null)
                adorner.Remove();

            e.Handled = true;
            return;
        }

        void AssociatedObject_DragLeave(object sender, DragEventArgs e)
        {
            if (adorner != null)
                adorner.Remove();
            e.Handled = true;
        }

        void AssociatedObject_DragOver(object sender, DragEventArgs e)
        {
            if (dataType != null)
            {
                //if item can be dropped
                if (e.Data.GetDataPresent(dataType))
                {
                    //give mouse effect
                    SetDragDropEffects(e);
                    //draw the dots
                    if (adorner != null)
                        adorner.Update();
                }
            }
            e.Handled = true;
        }

        void AssociatedObject_DragEnter(object sender, DragEventArgs e)
        {
            //if the DataContext implements IDropable, record the data type that can be dropped
            if (dataType == null)
            {
                if (AssociatedObject.DataContext != null)
                {
                    IDropable dropObject = AssociatedObject.DataContext as IDropable;
                    if (dropObject != null)
                    {
                        dataType = dropObject.DataType;
                    }
                }
            }

            if (adorner == null)
                adorner = new FrameworkElementAdorner(sender as UIElement);
            e.Handled = true;
        }

        private void SetDragDropEffects(DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;  //default to None

            //if the data type can be dropped 
            if (e.Data.GetDataPresent(dataType))
            {
                e.Effects = DragDropEffects.Move;
            }
        }
    }
}
