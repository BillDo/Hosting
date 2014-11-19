﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.DependencyInjection.Fallback;
using Microsoft.Framework.OptionsModel;
using Xunit;

namespace Microsoft.AspNet.Hosting.Tests
{
    public class UseServicesFacts
    {
        [Fact(Skip = "needs review")]
        public void OptionsAccessorCanBeResolvedAfterCallingUseServicesWithAction()
        {
            var baseServiceProvider = new ServiceCollection().BuildServiceProvider();
            var builder = new ApplicationBuilder(baseServiceProvider);

            builder.UseServices(serviceCollection => { });

            var optionsAccessor = builder.ApplicationServices.GetRequiredService<IOptions<object>>();
            Assert.NotNull(optionsAccessor);
        }


        [Fact(Skip = "needs review")]
        public void OptionsAccessorCanBeResolvedAfterCallingUseServicesWithFunc()
        {
            var baseServiceProvider = new ServiceCollection().BuildServiceProvider();
            var builder = new ApplicationBuilder(baseServiceProvider);
            IServiceProvider serviceProvider = null;

            builder.UseServices(serviceCollection =>
            {
                serviceProvider = serviceCollection.BuildServiceProvider();
                return serviceProvider;
            });

            Assert.Same(serviceProvider, builder.ApplicationServices);
            var optionsAccessor = builder.ApplicationServices.GetRequiredService<IOptions<object>>();
            Assert.NotNull(optionsAccessor);
        }
    }
}