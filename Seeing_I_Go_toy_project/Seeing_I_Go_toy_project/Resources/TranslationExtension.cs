using Seeing_I_Go_toy_project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Seeing_I_Go_toy_project.Resources
{
    [ContentProperty("Text")]
    public class TranslationExtension : IMarkupExtension<BindingBase>
    {
        public string Text { get; set; }
        public string StringFormat { get; set; }
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Text}]",
                Source = LocalizationResourceManager.Instance,
                StringFormat = StringFormat
            };
            return binding;
        }
    }
}
