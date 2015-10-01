using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iosystemlog.Databases.io_systemlog.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class LogTypes : View
    {
        public enum Fields
            {
                 LogTypeKey = 0,
                 LogTypeName = 1
            }

            public const Int16 LOGTYPENAME_MAXLENGTH = 50;

            private LogType DefaultValues(LogType row)
            {
                return row;
            }

            public static io.Data.Return<LogTypes.LogType> GetObjectWithKey(int key)
            { 
                using(LogTypes objects = new LogTypes(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<LogTypes.LogType>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<LogTypes.LogType>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tLogTypes";
                _source = @"tLogTypes";
                _id = @"LogTypeKey";
                _ioSystem = iosystemlog.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_systemlog.Database.ActiveConnection());

                base.Query();
            }

            public LogTypes(int logTypeKey, params Fields[] selectFields)
            {
                _where = "LogTypeKey = " + logTypeKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public LogTypes(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public LogTypes(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public LogTypes(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public LogType this[int index]
            {
                get { return (LogType)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new LogType(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(LogType);
            }

            public LogType NewLogType()
            {
                LogType row = (LogType)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class LogType : io.Data.ViewRow
            {

                internal LogType(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public int LogTypeKey
                {
                    get { return this.DBInteger(Fields.LogTypeKey.ToString()); }
                }

                public string LogTypeName
                {
                    get { return this.DBString(Fields.LogTypeName.ToString()); }
                    set { this.SetDBString(Fields.LogTypeName.ToString(), value, LOGTYPENAME_MAXLENGTH); }
                }
            }
        }
    }
