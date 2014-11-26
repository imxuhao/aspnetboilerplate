﻿using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace Abp.AutoMapper.Tests
{
    public class AutoMapping_Tests
    {
        static AutoMapping_Tests()
        {
            //ABP will automatically find and create these mappings!
            AutoMapperHelper.CreateMap(typeof(MyClass1));
        }

        [Fact]
        public void MapTo_Tests()
        {
            var obj1 = new MyClass1 { TestProp = "Test value" };

            var obj2 = obj1.MapTo<MyClass2>();
            obj2.TestProp.ShouldBe("Test value");

            var obj3 = obj1.MapTo<MyClass3>();
            obj3.TestProp.ShouldBe("Test value");
        }

        [Fact]
        public void MapFrom_Tests()
        {
            var obj2 = new MyClass2 { TestProp = "Test value" };

            var obj1 = obj2.MapTo< MyClass1>();
            obj1.TestProp.ShouldBe("Test value");
        }

        [Fact]
        public void MapTo_Collection_Tests()
        {
            var list1 = new List<MyClass1>
                        {
                            new MyClass1 {TestProp = "Test value 1"},
                            new MyClass1 {TestProp = "Test value 2"}
                        };

            var list2 = list1.MapTo<List<MyClass2>>();
            list2.Count.ShouldBe(2);
            list2[0].TestProp.ShouldBe("Test value 1");
            list2[1].TestProp.ShouldBe("Test value 2");
        }

        [AutoMap(typeof(MyClass2), typeof(MyClass3))]
        private class MyClass1
        {
            public string TestProp { get; set; }
        }

        private class MyClass2
        {
            public string TestProp { get; set; }
        }

        private class MyClass3
        {
            public string TestProp { get; set; }
        }
    }
}