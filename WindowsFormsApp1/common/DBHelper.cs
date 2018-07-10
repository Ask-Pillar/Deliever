using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.common
{

    public static class DBHelper
    {
        //数据库连接字符串
        public static string ConStr = ConfigurationManager.AppSettings["DBName"];

        //获取数据库资源对象
        public static SqlConnection con = null;

        //获取连接对象
        public static SqlConnection GetConnection()
        {
            if (con == null || con.ConnectionString == "")
            {
                con = new SqlConnection(ConStr);
            }
            return con;
        }

        //打开连接
        public static void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        //关闭连接
        public static void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        //查询
        public static DataTable GetTable(string sql, CommandType type = CommandType.Text, params SqlParameter[] pas)
        {
            DataTable dt = new DataTable();
            using (con = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.CommandType = type;
                if (pas != null)
                {
                    da.SelectCommand.Parameters.AddRange(pas);
                }
                da.Fill(dt);
                con.Close();
            }
            return dt;
        }

        //增删改
        public static int ExcuteSQL(string strSQL, CommandType cmdType = CommandType.Text, params SqlParameter[] paras)
        {
            int i = 0;
            using (con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.CommandType = cmdType;
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                OpenConnection();

                i = cmd.ExecuteNonQuery();

                con.Close();
            }
            return i;
        }

        //修改数据且获取ID
        public static int SelectId(string strSQL, CommandType cmdType = CommandType.Text, params SqlParameter[] paras)
        {
            int ID = Convert.ToInt32(null);

            using (con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(strSQL + "select  @@IDENTITY as 'ID'", con);
                cmd.CommandType = cmdType;
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                OpenConnection();

                ID = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();
            }
            return ID;
        }

        //大运单表#####(栋)
        public static string Delieversql(string Rename)
        {

            string deliever =
                @"select DelieverID as 运单编号, DelieverStartReporatoryID as 起始地ID,
                DelieverDestinationReporatoryID as 目的地ID,
                DelieverCreateDate as 开始时间, DelieverCompletedDate as 结束时间
                from Deliever
                join TransReporatory as T
                on Deliever.DelieverStartReporatoryID=T.TransReporatoryID
                where DelieverID in
                (
	                 select DelieverID
	                 from TranReporatoryGoods
	                 where TransReporatoryID=
	                 (
		                  select TransReporatoryID
		                  from  TransReporatory
		                  where TransReporatoryName= '" + Rename +
                     "') and TransNumber>0" +
                ") and DelieverStatus!=2";

            return deliever;


        }

        //子运单表##### 
        public static string SubDelieversql(int delid, string str)
        {

            string sql = @"select SubDeliverID as 编号,SubDeliverStartReporatoryID as 本站ID,
                                SubDeliverDestinationReporatoryID as 下一站ID,
                                SubDeliverSendDate as 创建时间,SubDeliverStatus as 状态码
                                from  SubDeliever 
                                where DelieverID= " + delid + " and SubDeliverStatus=0 " +
                           "and SubDeliverStartReporatoryID in" +
                           "(select TransReporatoryID from " +
                           "TransReporatory where TransReporatoryName = '" + str + "')";
            return sql;
        }

        //添加子订单sql#####
        public static string AddSubDelieversql(List<string> str)
        {
            string sql = "insert into SubDeliever(" +
                         "DelieverID,SendEmployeeID," +
                         "SubDeliverStartReporatoryID," +
                         "SubDeliverDestinationReporatoryID," +
                         "SubDeliverType,SubDeliverTrafficNumber," +
                         "SubDeliverStatus,SubDeliverSendDate) values(";
            int i = 0;
            for (; i < str.Count - 1; i++)
            {
                sql += "'" + str[i] + "', ";
            }
            sql += "'" + Convert.ToDateTime(str[i++]) + "') ";
            return sql;
        }

        //添加子运单货物的#####
        //public static string AddSubDelieverGoods(string ID, int subID, string number)
        //{
        //    return "insert into SubDeliverGoods(GoodsID,SubDeliverID," +
        //                 "SubDeliverTotalNumber)values('" + ID + "'," + subID + "'," + number + "')";
        //}

        //查询运单起止地#####

        public static string GetStartDestName(int repID)
        {
            return
                @"select  TransReporatoryName from TransReporatory where TransReporatoryID = " + repID;
        }

        //当前仓库关于当前订单的货物查询######
        public static string Goods(int delid, string This)
        {
            return
              @"select GoodsName from Goods
                where GoodsID in
                ( 
                  select GoodsID
                  from TranReporatoryGoods
                  where DelieverID= " + delid +
                  " and TransReporatoryID=(" +
                  "select TransReporatoryID from TransReporatory" +
                  " where TransReporatoryName='" + This +
                  "') and TransNumber>0 )";
        }

        //当前仓库某种货物的数量######
        public static string GoodsNumber(string goods)
        {
            return
                @"select TransNumber from TranReporatoryGoods
                  where GoodsID = (select GoodsID 
                  from Goods where GoodsName=" + goods + ")";
        }

        //获取货物ID#####
        public static string GoodsID(string goodsname)
        {
            return
                @"select GoodsID from Goods where GoodsName='" + goodsname + "'";
        }

        //查询仓库ID####
        public static string GetReID(string name)
        {
            return
                  @"select  TransReporatoryID from TransReporatory where TransReporatoryName = '" + name + "'";
        }

        //获取管理员id####
        public static string EmpolyeeID(string name)
        {
            return
                 @"select EmployeeID from Employee where EmployeeName  = '" + name + "'";
        }

        //获取仓库id(杨)
        public static string TransReporatoryId(string name)
        {
            return
                 @"select TransReporatoryID from TransReporatory where TransReporatoryName = '" + name + "'";
        }

        //添加大运单#####
        public static string AddDel(List<string> str)

        {
            string sql = "insert into Deliever(" +
                         "DelieverStartReporatoryID,EmployeeID," +
                         "DelieverDestinationReporatoryID,HaveSubDelievers," +
                         "DelieverStatus,DelieverCreateDate," +
                         "DelieverTransferReporatory)values(";
            int i = 0;
            for (; i < str.Count - 2; i++)
            {
                sql += "'" + str[i] + "', ";
            }
            sql += "'" + Convert.ToDateTime(str[i++]) + "', ";
            sql += "'" + str[i++] + "')";
            return sql;
        }

        //向中转站添加货物######
        public static string AddToTrabsReporGoods(string goodsid, string Trid, int number, int delid)
        {

            string sql = "insert into TranReporatoryGoods(" +
                "GoodsID,TransReporatoryID," +
                "TransNumber, DelieverID )values("
                + goodsid + "," + Trid + "," + number + "," + delid + ")";
            return sql;
        }

        //向中转站添加货物*********
        public static string AddTrabsReporGoods(List<string> str)
        {

            string sql = "insert into TranReporatoryGoods(" +
                 "GoodsID,TransReporatoryID," +
                    "TransNumber," + "DelieverID )values(";
            int i = 0;
            for (; i < str.Count - 1; i++)
            {
                sql += "'" + str[i] + "', ";
            }
            sql += "'" + str[i++] + "')";
            return sql;

        }

        //创建大订单货物####
        public static string Addbiggood(string str, int delid, int number)
        {
            return @"insert into DelieverGoods(GoodsID,DelieverID,DelieverTotalNumber)values('" +
                     str + "','" + delid + "','" + number + "')";
        }

        //创建子运单的货物
        public static string AddSubGoods(string goodsid, int subid, int number)
        {
            return @"insert into SubDeliverGoods(GoodsID,SubDeliverID,SubDeliverTotalNumber)values('" +
                    goodsid + "','" + subid + "','" + number + "')";
        }

        //获取大运单数量和大运单状态(梁)
        public static string HaveStatu(int delid)
        {
            return "select HaveSubDelievers,DelieverStatus from Deliever where DelieverID=" + delid;
        }

        //修改大运单状态(梁)
        public static string Modify(int status, int delid)
        {
            return "UPDATE Deliever SET  HaveSubDelievers = HaveSubDelievers+1  , DelieverStatus = " + status + " where DelieverID=" + delid;
        }

        //修改大运单状态(梁)
        public static string Modify(int have, int status, int delid)
        {
            return "UPDATE Deliever SET  HaveSubDelievers = " + have + " , DelieverStatus = " + status + " where DelieverID=" + delid;
        }

        //查询大订单代收状态(杨)
        public static string selectbigsta(string name)
        {
            return
                @"select de.DelieverID,de.DelieverTransferReporatory, sunbde.SubDeliverStartReporatoryID,sunbde.SubDeliverSendDate ,sunbde.SubDeliverDestinationReporatoryID,sunbde.SubDeliverStatus ,de.DelieverStatus from Deliever de join SubDeliever sunbde on de.DelieverID = sunbde.DelieverID join TransReporatory teanre on sunbde.SubDeliverDestinationReporatoryID = teanre.TransReporatoryID where(de.HaveSubDelievers = 1 and de.DelieverStatus = 1 and sunbde.SubDeliverStatus = 1 AND de.DelieverTransferReporatory = '" + name + "') or(de.HaveSubDelievers = 0 and de.DelieverStatus = 2 and sunbde.SubDeliverStatus = 0 AND de.DelieverTransferReporatory = '" + name + "')";
        }

        //查询货物数量(栋)
        public static string GoodsNumber(int delid, string thisname, string goodsname)
        {
            return @"select sum(TransNumber) from TranReporatoryGoods
                    where DelieverID= " + delid +
                    "and TransReporatoryID=" +
                    "(select TransReporatoryID from TransReporatory " +
                    "where TransReporatoryName='" + thisname + "')" +
                    "and GoodsID=" +
                    "( select GoodsID from Goods " +
                    "where GoodsName='" + goodsname + "')";
        }

        //发货修改中转站货物数量(栋)
        public static string GoodsReduce(int delid, string thisname, string goodsname, int number)
        {
            return "update TranReporatoryGoods set TransNumber=TransNumber-" + number +
                   "where DelieverID = " + delid +
                    "and TransReporatoryID=" +
                    "(select TransReporatoryID from TransReporatory " +
                    "where TransReporatoryName='" + thisname + "')" +
                    "and GoodsID=" +
                    "( select GoodsID from Goods " +
                    "where GoodsName='" + goodsname + "')";
        }

        //显示全部未完成大运单(栋)
        public static string EveryDel()
        {
            return
               @"select DelieverID as 运单编号, DelieverStartReporatoryID as 起始地ID,StartReporatoryName as 起始地,
                DelieverDestinationReporatoryID as 目的地ID,DestinationReporatoryName as 目的地,
                HaveSubDelievers as 子运单数量,DelieverCompletedDate as 创建日期
                from Deliever join 
                (
	                select TransReporatoryID as StartReporatoryID,
	                TransReporatoryName as  StartReporatoryName
	                from TransReporatory
                ) as S 
                on Deliever.DelieverStartReporatoryID=S. StartReporatoryID
                join 
                (
	                select TransReporatoryID as DestinationReporatoryID,
	                TransReporatoryName as DestinationReporatoryName
	                from TransReporatory
                ) as D 
                on Deliever.DelieverDestinationReporatoryID=D.DestinationReporatoryID
                where DelieverStatus !=2";
        }

        //显示当前大运单在途子运单(栋)
        public static string EverySubDel(int delid)
        {

            return
               @"select SubDeliever.SubDeliverID as 子运单编号, SubDeliverGoodsID as 货物运输ID,
                StartReporatoryName as 开始中转站,DestinationReporatoryName as 结束中转站,
                GoodsName as 货物名称, SubDeliverTotalNumber as 货物数量,SubDeliverType as 运输工具,
                SubDeliverTrafficNumber as 运输工具编号,SubDeliverSendDate as 发货日期
                from SubDeliever join SubDeliverGoods
                on SubDeliever.SubDeliverID=SubDeliverGoods.SubDeliverID
                join Goods 
                on SubDeliverGoods.GoodsID=Goods.GoodsID
                join
                (
	                select TransReporatoryID as StartReporatoryID,
	                TransReporatoryName as  StartReporatoryName
	                from TransReporatory
                ) as S
                on SubDeliever.SubDeliverStartReporatoryID=S.StartReporatoryID
                join
                (
	                select TransReporatoryID as DestinationReporatoryID,
	                TransReporatoryName as DestinationReporatoryName
	                from TransReporatory
                ) as D
                on SubDeliever.SubDeliverDestinationReporatoryID=D.DestinationReporatoryID
                where SubDeliverStatus=0 and DelieverID=" + delid;
        }

        //显示当前大运单在库的货物(栋)
        public static string GoodsInTranRe(int delid)
        {
            return
               @"select TranReporatoryGoods.GoodsID as 货物编号,GoodsName as 货物名称,                 
                sum(TransNumber) as 货物数量,TransReporatoryName as 所在仓库                 
                from TranReporatoryGoods join Goods                 
                on TranReporatoryGoods.GoodsID=Goods.GoodsID                  
                join TransReporatory on                   
                TranReporatoryGoods.TransReporatoryID=TransReporatory.TransReporatoryID                  
                where TransNumber>0 and DelieverID=" + delid +
                "group by TranReporatoryGoods.GoodsID,GoodsName,TransReporatoryName";

        }

        //查询大订单代收状态（志）
        public static string selectbigsta(string name, int id)
        {
            return
                @"select distinct de.DelieverID 运单编号  ,de.DelieverDestinationReporatoryID 终点站ID
                from deliever de
                join SubDeliever sude on de.DelieverID= sude.DelieverID
                where 
                  (de.DelieverStatus >0   and SubDeliverStatus = 0 
                  and sude.SubDeliverDestinationReporatoryID =(select tr.TransReporatoryID from TransReporatory tr where tr.TransReporatoryName like '%" + name + "%'))";
        }

        //获取ID(志)
        public static string deliverid(string name)
        {
            return
                @"select distinct de.DelieverID 订单编号
                    from deliever de
                join SubDeliever sude on de.DelieverID= sude.DelieverID
                where 
            (de.DelieverStatus >0   and SubDeliverStatus = 0 and DelieverTransferReporatory like '%" + name + "%')";
        }

        //修改子订单的状态(志)
        public static string ChangesSubStatus(int status, int delid)
        {
            string sql = "UPDATE SubDeliever SET SubDeliverStatus = " + status + " where SubDeliverID=" + delid + "";
            return sql;
        }

        //查询待收子订单（志）
        public static string WaitReaichSubDliver(int id, string name)
        {
            return
                @"
                select Distinct subdel.SubDeliverID 子运单编号, subdel.DelieverID 运单编号, sdg.GoodsID 货物ID,(Goods.GoodsName+':'+CAST(sdg.SubDeliverTotalNumber AS varchar))货物及货物量 ,subdel.SubDeliverType 运输类型, subdel.SubDeliverTrafficNumber 车船号
                from SubDeliever subdel join SubDeliverGoods sdg on subdel.SubDeliverID = sdg.SubDeliverID
                join Goods on Goods.GoodsID = sdg.GoodsID
                join Deliever on Deliever.DelieverID = subdel.DelieverID
                where 
	            subdel.SubDeliverDestinationReporatoryID =(
		        select Trans.TransReporatoryID 中转站编号
		        from TransReporatory Trans
		        where Trans.TransReporatoryName = '" + name + "') and subdel.SubDeliverStatus = 0 and sdg.SubDeliverTotalNumber > 0 and Deliever.DelieverStatus=1 and subdel.DelieverID=" + id;

        }

        //获取subid
        public static string WaitReaichSubDliver_OnlyID(int id, string name)
        {
            return
                @"
                select Distinct subdel.SubDeliverID 
                from SubDeliever subdel join SubDeliverGoods sdg on subdel.SubDeliverID = sdg.SubDeliverID
                join Goods on Goods.GoodsID = sdg.GoodsID
                join Deliever on Deliever.DelieverID = subdel.DelieverID
                where 
	            subdel.SubDeliverDestinationReporatoryID =(
		        select Trans.TransReporatoryID 中转站编号
		        from TransReporatory Trans
		        where Trans.TransReporatoryName = '" + name + "') and subdel.SubDeliverStatus = 0 and sdg.SubDeliverTotalNumber > 0 and Deliever.DelieverStatus=1 and subdel.DelieverID=" + id;

        }

        //转入真实的仓库（志）
        public static string AddToReallyReporGoods(List<string> str)
        {

            string sql = "insert into RealReportaryGoods(" +
                 "RealReportaryID,GoodsID," +
                    "RealNumber)values(";
            int i = 0;
            for (; i < str.Count - 1; i++)
            {
                sql += "'" + str[i] + "', ";
            }
            sql += "'" + str[i++] + "')";
            return sql;

        }

        //查询中转仓库的总量（志）
        public static string sunnum(string id, int tranID)
        {
            return
                   @"select sum(TransNumber) from TranReporatoryGoods where DelieverID ='" + id + "' and TransReporatoryID='" + tranID + "' group by DelieverID";
        }

        //查询大订的的货物量(志)
        public static string renum(string id)
        {

            return
                @"select sum(DelieverTotalNumber) from DelieverGoods where DelieverID = '" + id + "'group by DelieverID";
        }

        //查询大运单中的终点站ID
        public static string endtranID(int id)
        {

            return
                @"select DelieverDestinationReporatoryID from Deliever where DelieverID = '" + id + "'";
        }

        //查询大订单的拥有子订单的个数
        public static string havenum(int id)
        {

            return
                @"select HaveSubDelievers from Deliever where DelieverID = '" + id + "'";
        }

        //修改大订单中拥有子订单的个数
        public static string alterhave(int have, int delid)
        {
            return "UPDATE Deliever SET  HaveSubDelievers = " + have + "  where DelieverID=" + delid;
        }

        //获取货物ID，和货物数量
        public static string goodid(int delid)
        {
            return @"select GoodsID,SubDeliverTotalNumber from SubDeliverGoods
            where SubDeliverID ='" + delid + "' ";
        }

        //获取货物ID，和货物总量
        public static string NumAndGoodID(int delid, string tranid)
        {
            return @"select sum(TransNumber), GoodsID from TranReporatoryGoods where DelieverID ='" + delid + "' and TransReporatoryID='" + tranid + "' group by DelieverID,GoodsID ";
        }

        //根据仓库的ID，获取仓库名字
        public static string tranName(int id)
        {
            return @"select TransReporatoryName from TransReporatory where TransReporatoryID = '" + id + "'";
        }

        //根据仓库名字，获取真实仓库的ID
        public static string retranName(string name)
        {
            return @"select RealReportaryID from RealReportary where RealReportaryName = '" + name + "'";
        }

        //获取货物的名称
        public static string goodsName(string name)
        {
            return @"select count(GoodsName) from Goods where  GoodsName= '" + name + "'";
        }

        //获取管理员的编号
        public static string employeeNumber(string code)
        {
            return @"select count(EmployeeNumber) from Employee where EmployeeNumber = '" + code + "'";
        }
        public static string retan(string code)
        {
            return @"select count(*) from RealReportary where RealReportaryName='"+code+"'";
        }
        public static string tan(string code)
        {
            return @"sselect count(*) from TransReporatory where TransReporatoryName='"+code+"'";
        }

        //获取仓库的名称
        public static string TransReporatoryName()
        {
            return @"select * from TransReporatory";
        }
        public static string TransReporatoryName1()
        {
            return @"select TransReporatoryName from TransReporatory";
        }

        public static string GOODnam()
        {
            return @"select * from Goods";

        }
        





    }
}
