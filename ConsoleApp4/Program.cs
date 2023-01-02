using System.Collections;


namespace ConsoleApp4
{
    enum Fields
    {
        Ad,
        Soyad,
        Yas,
        Sehir
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DataRow row = new DataRow();
            row.AddValue("Nursen");
            row.AddValue("Özcan");
            row.AddValue(27);
            row.AddValue("İstanbul");

            DataTable dataTable = new DataTable();
            dataTable.Rows.Add(row);



            foreach (var rowItem in dataTable.Rows)
            {
                Console.WriteLine
                    (
                    rowItem[(int)Fields.Sehir].ToString()
                    );

                foreach (var column in rowItem)
                {
                    Console.WriteLine(column.ToString());
                }
            }

        }

        class DataTable 
        {
            public List<DataRow> Rows = new List<DataRow>();
        }
        class DataRow : IEnumerable, IEnumerator
        {
            private List<Object> internalData = new List<object>();

    

            public object Current => internalData[isaret];
            public void AddValue(object value)
            {
                internalData.Add(value);
            }
            public override string ToString()
            {
                return String.Join("; ", internalData);
            }

           
            
            int isaret = -1;
            public bool MoveNext()
            {
                if(isaret < this.internalData.Count -1) 
                { 
                    isaret++;
                    return true;
                }
                else { return false; }
            }

            public void Reset()
            {
               isaret = -1;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            
            public IEnumerator GetEnumerator()
            {
                return this;
            }

            public object this[int i]   //indexer
            {
                get
                {
                    return internalData[i];
                }
                set
                {
                    internalData[i] = value;
                }

            }
            public object this[Fields fields]
            {
                get
                {
                    return internalData[(int)fields];
                }

                set
                {
                    internalData[(int)fields] = value;
                }
            }
            public object this[String fields]
            {
                get
                {
                    int i = -1;
                    switch (fields)
                    {
                        case "Ad":
                                i = 0;
                            break;
                        case "Soyad":
                                i = 1;
                            break;
                            default:
                            break;
                    }
                    return internalData[i];
                }

            //    set
            //    {
            //        internalData[(int)fields] = value;
            //    }
            //}



        }
    }

}
