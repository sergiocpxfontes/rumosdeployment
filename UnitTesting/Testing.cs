using System;
using Xunit;
using Lib;
using System.Collections.Generic;

namespace UnitTesting
{
    public class Testing
    {
        [Fact]
        public void Teste_Soma()
        {
            Assert.Equal(3, Operations.Soma(1, 2));
        }
        [Fact(DisplayName = "Soma - Teste Negativo")]
        public void Teste_Soma2()
        {
            Assert.NotEqual(2, Operations.Soma(1, 2));
        }

        [Fact(DisplayName = "Soma 3 - Teste Negativo",Skip = "Está desatualizado")]
        public void Teste_Soma3()
        {
            Assert.NotEqual(2, Operations.Soma(1, 2));
        }

        [Theory]
        [InlineData(1,2,3,true)]
        [InlineData(2, 2, 4,true)]
        [InlineData(3, 2, 5,true)]
        [InlineData(10, 2,12,true)]
        [InlineData(19, 2,22,false)]
        public void Teste_Soma4(int a,int b,int r,bool testtype)
        {
            if(testtype)
            { 
                Assert.Equal(r, Operations.Soma(a, b));
            }
            else
            {
                Assert.NotEqual(r, Operations.Soma(a, b));
            }
        }

        [Theory]
        [MemberData(nameof(DadosTesteSoma))]
        public void Teste_Soma5(int a, int b, int r, bool testtype)
        {
            if (testtype)
            {
                Assert.Equal(r, Operations.Soma(a, b));
            }
            else
            {
                Assert.NotEqual(r, Operations.Soma(a, b));
            }
        }

        public static IEnumerable<object[]> DadosTesteSoma =>
           new List<object[]>
           {
                new object[] {1, 2, 3, true }
                ,new object[] {2, 2, 4, true }
                ,new object[] {3, 2, 5, true }
                ,new object[] {10, 2, 12, true }
                ,new object[] {19, 2, 22, false }
           };


        [Theory]
        [ClassData(typeof(TestData))]
        public void Teste_Soma6(int a, int b, int r, bool testtype)
        {
            if (testtype)
            {
                Assert.Equal(r, Operations.Soma(a, b));
            }
            else
            {
                Assert.NotEqual(r, Operations.Soma(a, b));
            }
        }


        [Theory]
        [InlineData("1976-8-25")]
        [InlineData("2002-8-25")]
        public void Teste_MaiorDeIdade(String value)
        {
            MyTesting.MaiorDeIdade(DateTime.Parse(value));
        }

    }

    public class MyTesting : Assert
    {
        public static void MaiorDeIdade(DateTime value)
        {
            Assert.True(value.AddYears(18) <= DateTime.Now);
        }
    }

}
