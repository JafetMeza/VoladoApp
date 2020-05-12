using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VoladoApp.Views.Pruebas
{
    public static class TasksExtensions
    {
        /// <summary>
        /// Utility method to fire and forget tasks, and avoid warnings
        /// </summary>
        /// <param name="task">Task to fire and forget</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async void FireAndForget(this Task task)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
