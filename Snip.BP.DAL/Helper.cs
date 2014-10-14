using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Snip.BP.BO;

namespace Snip.BP.Dal
{
    internal class Helper
    {
        const string idParamName = "@Codigo";
        const string concurrencyParamName = "@IdConcurrencia";

        internal static void SetSaveParameters(SqlCommand command, BusinessBase businessBase)
        {
            DbParameter idParam = command.CreateParameter();
            idParam.DbType = DbType.Int32;
            idParam.Direction = ParameterDirection.InputOutput;
            idParam.ParameterName = idParamName;
            if (businessBase.Codigo == -1)
            {
                idParam.Value = DBNull.Value;
            }
            else
            {
                idParam.Value = businessBase.Codigo;
            }
            command.Parameters.Add(idParam);

            DbParameter rowVersion = command.CreateParameter();
            rowVersion.ParameterName = concurrencyParamName;
            rowVersion.Direction = ParameterDirection.InputOutput;
            rowVersion.DbType = DbType.Binary;
            rowVersion.Size = 8;

            if (businessBase.IdConcurrencia == null)
            {
                rowVersion.Value = DBNull.Value;
            }
            else
            {
                rowVersion.Value = businessBase.IdConcurrencia;
            }
            command.Parameters.Add(rowVersion);

            DbParameter returnValue = command.CreateParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(returnValue);
        }

        internal static byte[] GetConcurrencyId(SqlCommand command)
        {
            return (byte[])command.Parameters[concurrencyParamName].Value;
        }

        internal static int GetBusinessBaseId(SqlCommand command)
        {
            return (int)command.Parameters[idParamName].Value;
        }

        #region Métodos de Conversión de Datos

        public static DateTime GetDateTime(object value)
        {
            DateTime dateValue = DateTime.MinValue;
            if ((value != null) && (value != DBNull.Value))
            {
                dateValue = (DateTime)value;
            }
            return dateValue;
        }

        public static DateTime? GetNullableDateTime(object value)
        {
            DateTime? dateTimeValue = null;
            DateTime dbDateTimeValue;
            if (value != null && !Convert.IsDBNull(value))
            {
                if (DateTime.TryParse(value.ToString(), out dbDateTimeValue))
                {
                    dateTimeValue = dbDateTimeValue;
                }
            }
            return dateTimeValue;
        }

        public static int GetInteger(object value)
        {
            int integerValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                int.TryParse(value.ToString(), out integerValue);
            }
            return integerValue;
        }

        public static int? GetNullableInteger(object value)
        {
            int? integerValue = null;
            int parseIntegerValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                if (int.TryParse(value.ToString(), out parseIntegerValue))
                {
                    integerValue = parseIntegerValue;
                }
            }
            return integerValue;
        }

        public static decimal GetDecimal(object value)
        {
            decimal decimalValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                decimal.TryParse(value.ToString(), out decimalValue);
            }
            return decimalValue;
        }

        public static decimal? GetNullableDecimal(object value)
        {
            decimal? decimalValue = null;
            decimal parseDecimalValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                if (decimal.TryParse(value.ToString(), out parseDecimalValue))
                {
                    decimalValue = parseDecimalValue;
                }
            }
            return decimalValue;
        }

        public static double GetDouble(object value)
        {
            double doubleValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                double.TryParse(value.ToString(), out doubleValue);
            }
            return doubleValue;
        }

        public static double? GetNullableDouble(object value)
        {
            double? doubleValue = null;
            double parseDoubleValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                if (double.TryParse(value.ToString(), out parseDoubleValue))
                {
                    doubleValue = parseDoubleValue;
                }
            }

            return doubleValue;
        }

        public static string GetString(object value)
        {
            string stringValue = string.Empty;
            if (value != null && !Convert.IsDBNull(value))
            {
                stringValue = value.ToString().Trim();
            }
            return stringValue;
        }

        public static bool GetBoolean(object value)
        {
            bool bReturn = false;
            if (value != null && value != DBNull.Value)
            {
                bReturn = Convert.ToBoolean(value);
            }
            return bReturn;
        }

        public static bool? GetNullableBoolean(object value)
        {
            bool? bReturn = null;
            if (value != null && value != DBNull.Value)
            {
                bReturn = (bool)value;
            }

            return bReturn;
        }

        public static T GetEnumValue<T>(string databaseValue) where T : struct
        {
            T enumValue = default(T);

            object parsedValue = Enum.Parse(typeof(T), databaseValue);
            if (parsedValue != null)
            {
                enumValue = (T)parsedValue;
            }

            return enumValue;
        }

        public static bool ReaderContainsColumnName(DataTable schemaTable, string columnName)
        {
            bool containsColumnName = false;
            foreach (DataRow row in schemaTable.Rows)
            {
                if (row["ColumnName"].ToString() == columnName)
                {
                    containsColumnName = true;
                    break;
                }
            }
            return containsColumnName;
        }
        #endregion
    }
}
