using CiccioGest.Domain.Common;
using CiccioGest.Domain.Documenti;
using Moq;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Xunit;

namespace CiccioGest.Test.Domain
{
    public class DomainEntityTest
    {
        [Fact]
        public void DomainEntityEqualityTest()
        {
            Assembly asm = typeof(Fattura).Assembly;
            var types = asm.GetTypes().Where(x => x.IsSubclassOf(typeof(DomainEntity)));
            foreach (Type type in types)
            {
                if (!type.IsAbstract)
                    Pippo(type);
            }
        }

        private void Pippo(Type type)
        {
            object fat1 = Activator.CreateInstance(type, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, null, CultureInfo.InvariantCulture);
            fat1.GetType().GetProperty("Id").SetValue(fat1, 1);
            object fat2 = Activator.CreateInstance(type, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, null, CultureInfo.InvariantCulture);
            fat2.GetType().GetProperty("Id").SetValue(fat2, 1);
            Assert.Equal(fat1, fat2);
            object fat3 = Activator.CreateInstance(type, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, null, CultureInfo.InvariantCulture);
            fat3.GetType().GetProperty("Id").SetValue(fat3, 2);
            Assert.NotEqual(fat1, fat3);
        }

        private void Pippo2(Type type)
        {
            var moq1 = CreateMock(type);
            //moq1.Setup
        }

        public static Mock CreateMock(Type type)
        {
            var creator = typeof(Mock<>).MakeGenericType(type);
            return (Mock)Activator.CreateInstance(creator);
        }
    }
}
