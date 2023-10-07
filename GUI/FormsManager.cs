using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebcamQuickProfiles.GUI
{
    public class FormsManager
    {
        private IServiceProvider serviceProvider;
        private readonly IconService iconService;

        public IDictionary<Type, Form> FormInstances { get; set; } = new Dictionary<Type, Form>();

        public FormsManager(IServiceProvider serviceProvider, IconService iconService)
        {
            this.serviceProvider = serviceProvider;
            this.iconService = iconService;
        }

        public T ShowForm<T>(T formInstance = null) where T : Form
        {
            FormInstances.TryGetValue(typeof(T), out var existingFormInstance);

            if (existingFormInstance != null)
            {
                existingFormInstance.BringToFront();
                return existingFormInstance as T;
            }

            if (formInstance is null)
            {
                formInstance = NewForm<T>();
            }

            formInstance.FormClosed += (s, e) => FormInstances[typeof(T)] = null;
            FormInstances[typeof(T)] = formInstance;
            formInstance.Icon = iconService.GetIcon();
            formInstance.ShowDialog();

            return formInstance;
        }

        public T NewForm<T>() where T : Form
        {
            return serviceProvider.GetService<T>();
        }

        public bool IsFormOpen<T>() where T : Form
        {
            FormInstances.TryGetValue(typeof(T), out var existingFormInstance);
            return existingFormInstance != null;
        }
    }
}
