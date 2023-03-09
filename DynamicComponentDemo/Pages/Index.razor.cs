using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace DynamicComponentDemo.Pages
{
    public partial class Index
    {
        // dynamic compontn holding type
        Type? customPageType { get; set; }
        // dictionary for dynamic component parameters
        Dictionary<string, object>? ComponentParameters { get; set; }
        // value received from dynamically created component
        int receivedValue { get; set; } = 0;
        // in case you need reference to the component instance...
        DynamicComponent? dcRef;

        public Index()
        {
            try
            {
                // get current assembly path, load component assembly from the same
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var asm = Assembly.LoadFrom(Path.Combine(path!, "DynamicComponent.dll"));

                customPageType = asm.GetType("DynamicComponent.DynamicComponent");
                ComponentParameters = new Dictionary<string, object> {
                    { "OnRefresh",
                       EventCallback.Factory.Create<int>(this, OnRefresh)
                    }
                };
            }
            catch(Exception ex)
            {
                // for sure one can manage with proper ILogger....
                // catch and swallow here to demo component fails if it's dll is missing in server app folder
                Console.WriteLine(ex.ToString());
            }
        }

        // Listener which receives updates from dynamic components
        public async Task OnRefresh(int count)
        {
            receivedValue = count;
            await Task.CompletedTask;
        }

    }
}
