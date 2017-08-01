using System.Windows.Input;

namespace SlpGenerator
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Random1 = new RoutedUICommand
            (
                "Random",
                "Random",
                typeof(CustomCommands)
            );
        public static readonly RoutedUICommand Exit = new RoutedUICommand
            (
                "Random",
                "Random",
                typeof(CustomCommands)
            );
    }
}
