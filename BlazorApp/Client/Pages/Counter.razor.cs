using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages
{
    public partial class Counter
    {
        [Inject] ServiceSingleton singleton { get; set; }
        [Inject] ServiceTransient transient { get; set; }
        [Inject] IJSRuntime js { get; set; } // Con esta instancia se puede acceder a archivos JavaScript

        IJSObjectReference module;
        private int currentCount = 0;
        private static int currentCountStatic = 0;
        
        private async Task IncrementCountFromJavaScript()
        {
            await js.InvokeVoidAsync("DotNetInstanceMethodTest", DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public async Task IncrementCount()
        {
            module = await js.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
            await module.InvokeVoidAsync("showAlert", "Hello world");

            currentCount++;
            currentCountStatic = currentCount;
            singleton.Value = currentCount;
            transient.Value = currentCount;

            await js.InvokeVoidAsync("DotNetStaticMethodTest");
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }
    }
}
