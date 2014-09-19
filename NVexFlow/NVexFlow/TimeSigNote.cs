//对应 timeSigNote.js
using System;
using NVexFlow.Model;

namespace NVexFlow
{
    public class TimeSigNote:Note
    {
        #region js直译部分
        public TimeSigNote(string timeSpec,double customPadding)
            : base(new NoteStruct() { duration = "b" })
        { }
        private void Init(string timeSpec,double customPadding)
        {
            TimeSignature timeSignature = new TimeSignature(timeSpec,customPadding);
            this.timeSig = timeSignature.GetTimeSig();
            this.SetWidth(this.timeSig.glyph.Metrics.Width);
            //// Note properties
            this.ignoreTicks = true;
        }
        public override Stave Stave
        {
            set
            {
                base.Stave = value;
            }
        }
        public override BoundingBox BoundingBox
        {
            get
            { return new BoundingBox(0,0,0,0); }
        }
        public TimeSigNote AddToModifierContext()
        {
            //* overridden to ignore */
            return this;
        }
        public new TimeSigNote PreFormat()
        {
            this.PreFormatted = true;
            return this;
        }
        public void Draw()
        {

        }
        #endregion


        #region 隐含字段
        protected TimeSig timeSig;
        public override string Category
        {
            get
            { throw new Exception("js文件没有这个属性。在Modifier分支里有一个属性叫Note，暂时写成了Note类型。为了让不同的Note都能点儿出Category，先在Note里加入了Category"); }
        }
        public override string GetCategory()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
