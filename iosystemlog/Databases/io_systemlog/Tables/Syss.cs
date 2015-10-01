using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iosystemlog.Databases.io_systemlog.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class Syss : View
    {
        public enum Fields
            {
                 SysKey = 0,
                 SysName = 1
            }

            public const Int16 SYSNAME_MAXLENGTH = 50;

            private Sys DefaultValues(Sys row)
            {
                return row;
            }

            public static io.Data.Return<Syss.Sys> GetObjectWithKey(int key)
            { 
                using(Syss objects = new Syss(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<Syss.Sys>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<Syss.Sys>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tSyss";
                _source = @"tSyss";
                _id = @"SysKey";
                _ioSystem = iosystemlog.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_systemlog.Database.ActiveConnection());

                base.Query();
            }

            public Syss(int sysKey, params Fields[] selectFields)
            {
                _where = "SysKey = " + sysKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public Syss(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public Syss(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public Syss(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public Sys this[int index]
            {
                get { return (Sys)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Sys(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(Sys);
            }

            public Sys NewSys()
            {
                Sys row = (Sys)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class Sys : io.Data.ViewRow
            {

                internal Sys(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public int SysKey
                {
                    get { return this.DBInteger(Fields.SysKey.ToString()); }
                }

                public string SysName
                {
                    get { return this.DBString(Fields.SysName.ToString()); }
                    set { this.SetDBString(Fields.SysName.ToString(), value, SYSNAME_MAXLENGTH); }
                }
            }
        }
    }
