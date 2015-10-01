using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iosystemlog.Databases.io_systemlog.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class Apps : View
    {
        public enum Fields
            {
                 AppKey = 0,
                 AppName = 1,
                 SysKey = 2
            }

            public const Int16 APPNAME_MAXLENGTH = 50;

            private App DefaultValues(App row)
            {
                return row;
            }

            public static io.Data.Return<Apps.App> GetObjectWithKey(int key)
            { 
                using(Apps objects = new Apps(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<Apps.App>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<Apps.App>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tApps";
                _source = @"tApps";
                _id = @"AppKey";
                _ioSystem = iosystemlog.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_systemlog.Database.ActiveConnection());

                base.Query();
            }

            public Apps(int appKey, params Fields[] selectFields)
            {
                _where = "AppKey = " + appKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public Apps(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public Apps(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public Apps(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public App this[int index]
            {
                get { return (App)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new App(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(App);
            }

            public App NewApp()
            {
                App row = (App)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class App : io.Data.ViewRow
            {

                internal App(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public int AppKey
                {
                    get { return this.DBInteger(Fields.AppKey.ToString()); }
                }

                public string AppName
                {
                    get { return this.DBString(Fields.AppName.ToString()); }
                    set { this.SetDBString(Fields.AppName.ToString(), value, APPNAME_MAXLENGTH); }
                }

                public int SysKey
                {
                    get { return this.DBInteger(Fields.SysKey.ToString()); }
                    set { this.SetDBInteger(Fields.SysKey.ToString(), value); }
                }
            }
        }
    }
