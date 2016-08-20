using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication4.Model;

namespace WpfApplication4.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<AnchorInfo> _AnchorList;

        public ObservableCollection<AnchorInfo> AnchorList
        {
            get { return _AnchorList ?? (_AnchorList = new ObservableCollection<AnchorInfo>()); }
            set { _AnchorList = value; RaisePropertyChanged("AnchorList"); }
        }

        private AnchorInfo _SelectedItem;

        public AnchorInfo SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; RaisePropertyChanged("SelectedItem"); }
        }


        public MainViewModel()
        {
            this.AnchorList.Add(new AnchorInfo() { DisplayTitle = "来电信息", AnchorName = EnumPoliceNavigatePoint.PointInputResource });
            this.AnchorList.Add(new AnchorInfo() { DisplayTitle = "接警信息", AnchorName = EnumPoliceNavigatePoint.PointIncept });
            this.AnchorList.Add(new AnchorInfo() { DisplayTitle = "调派信息", AnchorName = EnumPoliceNavigatePoint.PointCommand });
            this.AnchorList.Add(new AnchorInfo() { DisplayTitle = "警情处置过程记录", AnchorName = EnumPoliceNavigatePoint.PointProcess });
        }

        public void SetPoint(EnumPoliceNavigatePoint point)
        {
            foreach (var dto in this.AnchorList)
            {
                if (dto.AnchorName == point)
                {
                    this.SelectedItem = dto;
                }
            }
        }
    }

    public enum EnumPoliceNavigatePoint
    {
        /// <summary>
        /// 来电信息栏
        /// </summary>
        PointInputResource,
        /// <summary>
        /// 接警信息栏
        /// </summary>
        PointIncept,
        /// <summary>
        /// 处警调度栏
        /// </summary>
        PointCommand,
        /// <summary>
        /// 处置过程记录
        /// </summary>
        PointProcess,
    }
}
