using Controllers;
using Model;
using Model.Mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDA_LBApi.Controllers
{
    public class PDAController : AllTransferPubic
    {
        //
        // GET: /PDA/

       /// <summary>
       /// 登录
       /// </summary>
       /// <param name="S"></param>
       /// <returns></returns>
        [ReturnClass(typeof(LoginMode.LoginReturn), "会员登录")]
        private Model.GeneralReturns Login(LoginMode.LoginRequest S)
        {
           
            return new BLL.Bll_Login().Login(S);
        }

        /// <summary>
        /// 入库上架或盘点
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "入库上架或盘点")]
        private Model.GeneralReturns inplace(Model.M_inplaceRequest S)
        {
            return new BLL.Bll_inplace().PutawayInventory(S);
        }

        /// <summary>
        /// 拣货下架列表信息
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "拣货下架列表信息")]
        private Model.GeneralReturns get_order_detail(Model.M_OffShelf.OffShelfRequest S)
        {
            return new BLL.BllGet_order_detail().GetOrderDetail(S);
        }


        /// <summary>
        ///   快递单号拣货或异常拣货
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "快递单号拣货或异常拣货")]
        private Model.GeneralReturns NumberOffShelf(Model.M_NumberOffShelf.Request S)
        {
            return new BLL.Bll_NumberOffShelf().NumberOffShelf(S);
        }


        /// <summary>
        ///   拣货完成或异常拣货完
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "拣货完成或异常拣货完")]
        private Model.GeneralReturns Picking(Model.M_Picking.Request S)
        {

            return new BLL.Bll_Picking().Picking(S);

        }


        /// <summary>
        /// 拣货中止异常
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "拣货中止异常")]
        private Model.GeneralReturns PickingStop(Model.M_PickingStop.Request S)
        {

            return new BLL.Bll_PickingStop().PickingStop(S);

        }


        /// <summary>
        ///   释放拣货任务
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "释放拣货任务")]
        private Model.GeneralReturns IStask(Model.M_IStask.Request S)
        {

            return new BLL.Bll_IStask().IStask(S);

        }

        /// <summary>
        /// 异常拣货清单
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "异常拣货清单")]
        private Model.GeneralReturns AbnormalPicking(Model.M_AbnormalPicking.Request S)
        {

            return new BLL.Bll_AbnormalPicking().AbnormalPicking(S);

        }

        /// <summary>
        /// 异常拣货拣货下架列表信息
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "异常拣货拣货下架列表信息")]
        private Model.GeneralReturns AbnormalPickingList(Model.M_AbnormalPickingList.Request S)
        {

            return new BLL.Bll_AbnormalPickingList().AbnormalPickingList(S);

        }

        /// <summary>
        /// 获取核单列表
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "获取核单列表")]
        private Model.GeneralReturns CheckOrderInfo(Model.M_CheckOrderInfo.Request S)
        {

            return new BLL.Bll_CheckOrderInfo().CheckOrderInfo(S);

        }

        /// <summary>
        /// 核单取快递单的信息
        /// </summary>
        [ReturnClass(null, "核单取快递单的信息")]
        private Model.GeneralReturns CheckBillcodeInfo(Model.M_CheckBillcodeInfo.Request S)
        {
            return new BLL.Bll_CheckBillcodeInfo().CheckBillcodeInfo(S);

        }

        /// <summary>
        ///  核单打包
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "核单打包")]
        private Model.GeneralReturns Print(Model.M_Print.Request S)
        {

            return new BLL.Bll_Print().Print(S);

        }

        /// <summary>
        ///  自提点发货
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "自提点发货")]
        private Model.GeneralReturns ZTsendGoods(Model.M_ZTsendGoods.Request S)
        {

            return new BLL.Bll_ZTsendGoods().ZTsendGoods(S);

        }


        /// <summary>
        ///  自提点入库上架
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "自提点入库上架")]
        private Model.GeneralReturns ZTPutaway(Model.M_ZTPutaway.Request S)
        {

            return new BLL.Bll_ZTPutaway().ZTPutaway(S);

        }



        /// <summary>
        /// 快递交单
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "快递交单")]
        private Model.GeneralReturns KD_jd(Model.M_KD_jd.Request S)
        {

            return new BLL.Bll_KD_jd().kd_jd(S);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        [ReturnClass(null, "同行交单")]
        private Model.GeneralReturns PeerDeliverBill(Model.M_PeerDeliverBill.Request S)
        {
            return new BLL.Bll_PeerDeliverBill().PeerDeliverBill(S);
        }

        /// <summary>
        /// 推送消息给客服
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "推送消息给客服")]
        private Model.GeneralReturns PushMessage(Model.M_PushMessage.Request S)
        {

            return new BLL.Bll_PushMessage().PushMessage(S);

        }


        /// <summary>
        ///  获取仓库列表
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(typeof(Model.M_wavehouse), "获取仓库列表")]
        private Model.GeneralReturns wavehouseList(Model.M_wavehouse.Request S)
        {

            return new BLL.Bll_wavehouseList().wavehouseList();

        }

        /// <summary>
        ///  获取自提点列表
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "获取自提点列表")]
        private Model.GeneralReturns ztPriceList(Model.M_ztPriceList.Request S)
        {

            return new BLL.Bll_ztPriceList().ztPriceList();

        }

        /// <summary>
        ///  快递公司信息
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "快递公司信息")]
        private Model.GeneralReturns KD_comInfo(Model.M_KD_comInfo.Request S)
        {

            return new BLL.Bll_KD_comInfo().KD_comInfo();

        }



        /// <summary>
        /// 获取承运商
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "获取承运商")]
        private Model.GeneralReturns Forwarder(Model.M_KD_comInfo.Request S)
        {

            return new BLL.Bll_Forwarder().Forwarder();

        }

        /// <summary>
        /// 获取同行资料
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "获取同行资料")]
        private Model.GeneralReturns PeerInfo(Model.M_PeerInfo.Request S)
        {

            return new BLL.Bll_PeerInfo().PeerInfo();

        }


      

        /// <summary>
        /// 获取店铺
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "获取店铺")]
        private Model.GeneralReturns ShopList(Model.M_ShopList.Request S)
        {

            return new BLL.Bll_ShopList().ShopList();

        }


        /// <summary>
        /// 极光推送
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [ReturnClass(null, "极光推送")]
        private Model.GeneralReturns JPushSent(Model.JPushMode S)
        {
            return new BLL.Bll_JPushSent().JPushSent(S);
        }


        /// <summary>
        /// 获取服务器[Wsy_androidpda]版本号Json格式 包含vosoin版本号 geturl 下载链接 Rem 更新说明
        /// </summary>
        private Model.GeneralReturns GetVosionNo(Model.M_GetVosionNo.Request S)
        {
            Model.GeneralReturns gr = new Model.GeneralReturns();
            gr.ReturnJson = Common.DataHandling.ObjToJson(new BLL.Bll_GetVosionNo().GetVosionNo());
            return gr;
        }

        /// <summary>
        /// 获取服务器[Wsy_androidpda]版本号Json格式 包含vosoin版本号 geturl 下载链接 Rem 更新说明
        /// </summary>
        public string GetVosionNo()
        {
            return Common.DataHandling.ObjToJson(new BLL.Bll_GetVosionNo().GetVosionNo());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weight">重量</param>
        /// <param name="size">尺寸</param>
        /// <returns>true/false</returns>
        // [ReturnClass(null, "承运商重量尺寸规格")]
        //private Model.GeneralReturns CarrierWeightDimensions(string weight,string size)
        //{
            
        //}

    }
}
