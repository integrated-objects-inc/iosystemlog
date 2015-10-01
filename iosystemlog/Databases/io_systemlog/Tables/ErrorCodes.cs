using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iosystemlog.Databases.io_systemlog.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class ErrorCodes : View
    {
        public enum Fields
            {
                 ErrorCodeKey = 0,
                 ErrorCodeName = 1
            }

            public const Int16 ERRORCODENAME_MAXLENGTH = 255;

            private ErrorCode DefaultValues(ErrorCode row)
            {
                return row;
            }

            public static io.Data.Return<ErrorCodes.ErrorCode> GetObjectWithKey(int key)
            { 
                using(ErrorCodes objects = new ErrorCodes(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<ErrorCodes.ErrorCode>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<ErrorCodes.ErrorCode>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tErrorCodes";
                _source = @"tErrorCodes";
                _id = @"ErrorCodeKey";
                _ioSystem = iosystemlog.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_systemlog.Database.ActiveConnection());

                base.Query();
            }

            public ErrorCodes(int errorCodeKey, params Fields[] selectFields)
            {
                _where = "ErrorCodeKey = " + errorCodeKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ErrorCodes(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ErrorCodes(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ErrorCodes(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ErrorCode this[int index]
            {
                get { return (ErrorCode)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new ErrorCode(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(ErrorCode);
            }

            public ErrorCode NewErrorCode()
            {
                ErrorCode row = (ErrorCode)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class ErrorCode : io.Data.ViewRow
            {

                internal ErrorCode(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public int ErrorCodeKey
                {
                    get { return this.DBInteger(Fields.ErrorCodeKey.ToString()); }
                }

                public string ErrorCodeName
                {
                    get { return this.DBString(Fields.ErrorCodeName.ToString()); }
                    set { this.SetDBString(Fields.ErrorCodeName.ToString(), value, ERRORCODENAME_MAXLENGTH); }
                }
            }
        }
    }
