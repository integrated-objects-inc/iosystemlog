using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iosystemlog.Databases.io_systemlog.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class SysLogs : View
    {
        public enum Fields
            {
                 AppKey = 0,
                 DateCreated = 1,
                 Description = 2,
                 ErrorCodeKey = 3,
                 ExceptionMessage = 4,
                 FunctionName = 5,
                 GUIMessage = 6,
                 ParamsIn = 7,
                 ParamsOut = 8,
                 Returned = 9,
                 SQL = 10,
                 SysKey = 11,
                 SysLogKey = 12,
                 SystemInstallKey = 13,
                 UserSessionKey = 14
            }

            public const Int16 DESCRIPTION_MAXLENGTH = 1024;
            public const Int16 EXCEPTIONMESSAGE_MAXLENGTH = 8000;
            public const Int16 FUNCTIONNAME_MAXLENGTH = 100;
            public const Int16 GUIMESSAGE_MAXLENGTH = 8000;
            public const Int16 PARAMSIN_MAXLENGTH = 8000;
            public const Int16 PARAMSOUT_MAXLENGTH = 8000;
            public const Int16 SQL_MAXLENGTH = 8000;

            private SysLog DefaultValues(SysLog row)
            {
                return row;
            }

            public static io.Data.Return<SysLogs.SysLog> GetObjectWithKey(int key)
            { 
                using(SysLogs objects = new SysLogs(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<SysLogs.SysLog>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<SysLogs.SysLog>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tSysLogs";
                _source = @"tSysLogs";
                _id = @"SysLogKey";
                _ioSystem = iosystemlog.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_systemlog.Database.ActiveConnection());

                base.Query();
            }

            public SysLogs(int sysLogKey, params Fields[] selectFields)
            {
                _where = "SysLogKey = " + sysLogKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public SysLogs(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public SysLogs(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public SysLogs(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public SysLog this[int index]
            {
                get { return (SysLog)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SysLog(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(SysLog);
            }

            public SysLog NewSysLog()
            {
                SysLog row = (SysLog)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class SysLog : io.Data.ViewRow
            {

                internal SysLog(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public int AppKey
                {
                    get { return this.DBInteger(Fields.AppKey.ToString()); }
                    set { this.SetDBInteger(Fields.AppKey.ToString(), value); }
                }

                public string DateCreated
                {
                    get { return this.DBDate(Fields.DateCreated.ToString()); }
                }

                public string Description
                {
                    get { return this.DBString(Fields.Description.ToString()); }
                    set { this.SetDBString(Fields.Description.ToString(), value, DESCRIPTION_MAXLENGTH); }
                }

                public int ErrorCodeKey
                {
                    get { return this.DBInteger(Fields.ErrorCodeKey.ToString()); }
                    set { this.SetDBInteger(Fields.ErrorCodeKey.ToString(), value); }
                }

                public string ExceptionMessage
                {
                    get { return this.DBString(Fields.ExceptionMessage.ToString()); }
                    set { this.SetDBString(Fields.ExceptionMessage.ToString(), value, EXCEPTIONMESSAGE_MAXLENGTH); }
                }

                public string FunctionName
                {
                    get { return this.DBString(Fields.FunctionName.ToString()); }
                    set { this.SetDBString(Fields.FunctionName.ToString(), value, FUNCTIONNAME_MAXLENGTH); }
                }

                public string GUIMessage
                {
                    get { return this.DBString(Fields.GUIMessage.ToString()); }
                    set { this.SetDBString(Fields.GUIMessage.ToString(), value, GUIMESSAGE_MAXLENGTH); }
                }

                public string ParamsIn
                {
                    get { return this.DBString(Fields.ParamsIn.ToString()); }
                    set { this.SetDBString(Fields.ParamsIn.ToString(), value, PARAMSIN_MAXLENGTH); }
                }

                public string ParamsOut
                {
                    get { return this.DBString(Fields.ParamsOut.ToString()); }
                    set { this.SetDBString(Fields.ParamsOut.ToString(), value, PARAMSOUT_MAXLENGTH); }
                }

                public bool Returned
                {
                    get { return this.DBBoolean(Fields.Returned.ToString()); }
                    set { this.SetDBBoolean(Fields.Returned.ToString(), value); }
                }

                public string SQL
                {
                    get { return this.DBString(Fields.SQL.ToString()); }
                    set { this.SetDBString(Fields.SQL.ToString(), value, SQL_MAXLENGTH); }
                }

                public int SysKey
                {
                    get { return this.DBInteger(Fields.SysKey.ToString()); }
                    set { this.SetDBInteger(Fields.SysKey.ToString(), value); }
                }

                public int SysLogKey
                {
                    get { return this.DBInteger(Fields.SysLogKey.ToString()); }
                }

                public int SystemInstallKey
                {
                    get { return this.DBInteger(Fields.SystemInstallKey.ToString()); }
                    set { this.SetDBInteger(Fields.SystemInstallKey.ToString(), value); }
                }

                public int UserSessionKey
                {
                    get { return this.DBInteger(Fields.UserSessionKey.ToString()); }
                    set { this.SetDBInteger(Fields.UserSessionKey.ToString(), value); }
                }
            }
        }
    }
