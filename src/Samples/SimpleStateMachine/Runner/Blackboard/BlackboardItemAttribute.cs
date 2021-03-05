using System;

namespace SimpleStateMachine
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class BlackboardItemAttribute : Attribute
    {
        public BlackboardItemAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; }
    }
}
