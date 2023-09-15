using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
    public class TestData : IEnumerable<object[]>
    {

        IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
        {

            using (TextFieldParser parser = new TextFieldParser("dados.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    yield return new object[] { int.Parse(fields[0]), int.Parse(fields[1]), int.Parse(fields[2]), (int.Parse(fields[3]) == 1 ? true : false) };
                    //foreach(string field in fields)
                    //{

                    //}
                }
            }


            //    yield return new object[] { 1, 2, 3, true };
            //yield return new object[] { 2, 2, 4, true };
            //yield return new object[] { 3, 2, 5, true };
            //yield return new object[] { 10, 2, 12, true };
            //yield return new object[] { 19, 2, 22, false };
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
