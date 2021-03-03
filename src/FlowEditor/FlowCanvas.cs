using System.Windows;
using System.Windows.Controls;

namespace VFlow
{
    public class FlowCanvas : Panel
    {
        static FlowCanvas()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlowCanvas), new FrameworkPropertyMetadata(typeof(FlowCanvas)));
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                var internalChild = (ItemContainer)InternalChildren[i];
                internalChild.Arrange(new Rect(internalChild.Location, internalChild.DesiredSize));
            }

            return arrangeSize;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            Size availableSize = new Size(double.PositiveInfinity, double.PositiveInfinity);

            for (int i = 0; i < InternalChildren.Count; i++)
            {
                InternalChildren[i].Measure(availableSize);
            }

            return default;
        }
    }
}
