using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public enum DataCategory
    {
        SQLDB,
        MSExcel
    }

    [Export(typeof(IPlugin))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DataAccess : IPlugin
    {

        #region Private Properties

        private DbConnection Connection;

        private DbCommand Command;

        private DbDataAdapter Adapter;

        #endregion Private Properties

        #region Public Properties

        public DataCategory DataCategory { get; set; }

        public string ConectionString { get; set; }

        public string QueryString { get; set; }

        #endregion Public Properties

        #region Public Methods

        public T GetConnection<T>() where T : DbConnection
        {
            CreateConection();
            return (T)Connection;
        }

        public T GetCommand<T>() where T : DbCommand
        {
            CreateCommand();
            return (T)Command;
        }

        public T GetAdapter<T>() where T : DbDataAdapter
        {
            return (T)Adapter;
        }

        public DataSet GetData()
        {
            DataSet aDataSet = new DataSet();

            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    CreateDataAdapter();
                    GetAdapter<SqlDataAdapter>().SelectCommand = GetCommand<SqlCommand>();
                    GetAdapter<SqlDataAdapter>().Fill(aDataSet);
                    break;

                case DataCategory.MSExcel:
                    CreateDataAdapter();
                    GetAdapter<OleDbDataAdapter>().SelectCommand = GetCommand<OleDbCommand>();
                    GetAdapter<OleDbDataAdapter>().Fill(aDataSet);
                    break;
            }

            Connection.Close();
            Connection = null;
            Command = null;
            Adapter = null;

            return aDataSet;
        }

        public IEnumerable<IDataRecord> GetDataRecord()
        {
            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    CreateDataAdapter();

                    using (SqlDataReader Reader = GetCommand<SqlCommand>().ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            yield return Reader;
                        }
                    }
                    break;

                case DataCategory.MSExcel:
                    CreateDataAdapter();
                    using (OleDbDataReader Reader = GetCommand<OleDbCommand>().ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            yield return Reader;
                        }
                    }
                    break;
            }

            Connection.Close();
            Connection = null;
            Command = null;
            Adapter = null;
        }

        public List<T> GetData<T>()
        {
            List<T> data = null;
            CreateDataAdapter();
            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    using (Connection)
                    {
                        SqlDataReader reader = GetCommand<SqlCommand>().ExecuteReader();
                        data = DataMapper.CreateList<T>(reader);
                        return data;
                    }
                    break;

                case DataCategory.MSExcel:
                    using (Connection)
                    {
                        OleDbDataReader reader = GetCommand<OleDbCommand>().ExecuteReader();
                        data = DataMapper.CreateList<T>(reader);
                        return data;
                    }
                    break;
            }

            return data;
        }

        public List<T> GetData<T, TCommand>(Action<TCommand> command) where TCommand : DbCommand
        {
            List<T> data = null;
            CreateDataAdapter();
            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    using (Connection)
                    {
                        TCommand cmd = GetCommand<TCommand>();
                        command(cmd);
                        SqlDataReader reader = (SqlDataReader)cmd.ExecuteReader();
                        data = DataMapper.CreateList<T>(reader);
                        return data;
                    }
                    break;

                case DataCategory.MSExcel:
                    using (Connection)
                    {
                        TCommand cmd = GetCommand<TCommand>();
                        command(cmd);
                        OleDbDataReader reader = (OleDbDataReader)cmd.ExecuteReader();
                        data = DataMapper.CreateList<T>(reader);
                        return data;
                    }
                    break;

            }

            return data;
        }

        public void ExecuteCommand()
        {
            try
            {
                switch (DataCategory)
                {
                    case DataCategory.SQLDB:
                        CreateDataAdapter();
                        GetCommand<SqlCommand>().ExecuteNonQuery();
                        //GetAdapter<SqlDataAdapter>().Fill(aDataSet);
                        break;

                    case DataCategory.MSExcel:
                        CreateDataAdapter();
                        GetCommand<OleDbCommand>().ExecuteNonQuery();
                        //GetAdapter<OleDbDataAdapter>().Fill(aDataSet);
                        break;
                }
            }
            catch (DataException e)
            {
                //throw new DataBaseException("Exception occured while updating the data.", e);
            }
            finally
            {
                Connection.Close();
                Connection = null;
                Command = null;
                Adapter = null;
            }
        }

        public void ExecuteCommand<TCommand>(Action<TCommand> command) where TCommand : DbCommand
        {
            try
            {
                CreateDataAdapter();

                TCommand cmd = GetCommand<TCommand>();
                command(cmd);
                cmd.ExecuteNonQuery();
                //switch (DataCategory)
                //{
                //    case DataCategory.SQLDB:
                //        using (Connection)
                //        {
                //            TCommand cmd = GetCommand<TCommand>();
                //            command(cmd);
                //            cmd.ExecuteNonQuery();
                //        }

                //        break;

                //    case DataCategory.MSExcel:
                //        using (Connection)
                //        {
                //            OleDbCommand cmd = GetCommand<OleDbCommand>();
                //            command(cmd);
                //            cmd.ExecuteNonQuery();
                //        }

                //        break;
                //}
            }
            catch (DataException e)
            {
               // throw new DataBaseException("Exception occured while updating the data.", e);
            }
            finally
            {
                Connection.Close();
                Connection = null;
                command = null;
                Adapter = null;
            }
        }


        #endregion Public Methods

        #region Private Methods

        private void CreateConection()
        {
            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    Connection = new SqlConnection(ConectionString);
                    Connection.Open();
                    break;

                case DataCategory.MSExcel:
                    Connection = new System.Data.OleDb.OleDbConnection(ConectionString);
                    Connection.Open();
                    break;
            }
        }

        private void CreateDataAdapter()
        {
            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    Adapter = new SqlDataAdapter();
                    break;

                case DataCategory.MSExcel:
                    Adapter = new OleDbDataAdapter();
                    break;
            }
        }

        private void CreateCommand()
        {
            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    Command = new SqlCommand(QueryString, GetConnection<SqlConnection>());
                    break;

                case DataCategory.MSExcel:
                    Command = new OleDbCommand(QueryString, GetConnection<OleDbConnection>());
                    break;
            }
        }



        #endregion Private Methods

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
