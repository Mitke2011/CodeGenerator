using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using NUnitTestClasses;

namespace NUnitTests
{
    [TestFixture]
    public class TestProizvod
    {
        [Test]
        public void TestobjectValues()
        {
            Proizvod pr = new Proizvod();
            pr.KolicinaProperty = 5;
            pr.NazivProperty = "Lg Optimus";

            int expectedkolicina = 5;
            string expectedName = "Lg Optimus";
            Assert.AreEqual(expectedName,pr.NazivProperty);
            Assert.AreEqual(expectedkolicina,pr.KolicinaProperty);
        }

        public void GenericTest(string methodName)
        {
            Assembly assembly = Assembly.LoadFile("...DomenskaBiblioteka.dll");
            Type type = assembly.GetType("Biblioteka.Imeklase"); // postaviti iteraciju koja prolazi kroz sve tipove u bibioteci
            if (type != null)
            {
                MethodInfo methodInfo = type.GetMethod(methodName);
                if (methodInfo != null)
                {
                    object result = null;
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    object classInstance = Activator.CreateInstance(type, null);
                    if (parameters.Length == 0)
                    {
                        
                        result = methodInfo.Invoke(classInstance, null); //pozivanje metode preko refleksije
                    }
                    else
                    {
                        object[] parametersArray = new object[] { "Hello" };

                                
                        result = methodInfo.Invoke(classInstance, parametersArray);
                    }
                }
            }

            //setovanje vreednosti polja klase preko refleksije
            //Class1 klasa = new Class1();
            //string value = "5.5";
            //PropertyInfo propertyInfo = klasa.GetType().GetProperty("Prop1");
            //propertyInfo.SetValue(klasa, Convert.ChangeType(value, propertyInfo.PropertyType), null);

            //Pravim instancu klase tako sto pozivam njen konstruktor koji prima parametar. Ovako se mogu proveriti nicijalne vrednosti polja klase. 
            //Type typeK = typeof(Class1);
            //ConstructorInfo ctor = typeK.GetConstructor(new[] { typeof(int) });
            //object instance = ctor.Invoke(new object[] { 10 });
        }
    }
}
