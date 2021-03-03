﻿using System.Windows;
using System.Windows.Controls;

namespace VFlow
{
    /// <summary>
    /// Represents the default control for the <see cref="Node.InputConnectorTemplate"/>.
    /// </summary>
    public class NodeInput : Connector
    {
        #region Dependency Properties

        public static readonly DependencyProperty HeaderProperty = HeaderedContentControl.HeaderProperty.AddOwner(typeof(NodeInput));
        public static readonly DependencyProperty HeaderTemplateProperty = HeaderedContentControl.HeaderTemplateProperty.AddOwner(typeof(NodeInput));
        public static readonly DependencyProperty ConnectorTemplateProperty = DependencyProperty.Register(nameof(ConnectorTemplate), typeof(ControlTemplate), typeof(NodeInput));

        /// <summary>
        /// Gets of sets the data used for the control's header.
        /// </summary>
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Gets or sets the template used to display the content of the control's header.
        /// </summary>
        public DataTemplate HeaderTemplate
        {
            get => (DataTemplate)GetValue(HeaderTemplateProperty);
            set => SetValue(HeaderTemplateProperty, value);
        }

        /// <summary>
        /// Gets or sets the template used to display the connecting point of this <see cref="Connector"/>.
        /// </summary>
        public ControlTemplate ConnectorTemplate
        {
            get => (ControlTemplate)GetValue(ConnectorTemplateProperty);
            set => SetValue(ConnectorTemplateProperty, value);
        }

        #endregion

        static NodeInput()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NodeInput), new FrameworkPropertyMetadata(typeof(NodeInput)));
        }
    }
}
