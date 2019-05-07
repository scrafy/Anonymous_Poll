using System;
using Anonymous_Poll.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Anonymous_Poll.Infraestructure.Binders.Providers
{
    public class ModelBinderProvider : IModelBinderProvider
    {
        public ModelBinderProvider()
        {
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Input))
            {
                return new InputCaseModelBinder();
            }
            return null;
        }
    }
}
