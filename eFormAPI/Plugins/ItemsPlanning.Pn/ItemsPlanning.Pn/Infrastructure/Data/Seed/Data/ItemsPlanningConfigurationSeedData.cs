/*
The MIT License (MIT)

Copyright (c) 2007 - 2020 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Entities;

namespace ItemsPlanning.Pn.Infrastructure.Data.Seed.Data
{
    public class ItemsPlanningConfigurationSeedData : IPluginConfigurationSeedData
    {
        public PluginConfigurationValue[] Data => new[]
        {
            new PluginConfigurationValue()
            {
                Name = "ItemsPlanningBaseSettings:LogLevel",
                Value = "4"
            },
            new PluginConfigurationValue()
            {
                Name = "ItemsPlanningBaseSettings:LogLimit",
                Value = "25000"
            },
            new PluginConfigurationValue()
            {
                Name = "ItemsPlanningBaseSettings:SdkConnectionString",
                Value = "..."
            },
            new PluginConfigurationValue()
            {
                Name = "ItemsPlanningBaseSettings:MaxParallelism",
                Value = "1"
            },
            new PluginConfigurationValue()
            {
                Name = "ItemsPlanningBaseSettings:NumberOfWorkers",
                Value = "1"
            },
            new PluginConfigurationValue()
            {
                Name = "ItemsPlanningBaseSettings:SiteIds",
                Value = ""
            },
            new PluginConfigurationValue()
            {
            Name = "ItemsPlanningBaseSettings:Token",
            Value = "..."
            }
        };
    }
}