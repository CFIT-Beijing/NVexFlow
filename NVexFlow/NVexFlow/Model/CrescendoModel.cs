namespace NVexFlow.Model
{
    public class CrescendoStruct:NoteStruct
    {
        public int? line;
    }
    public class RenderHairpinParams
    {
        public double begin_x;
        public double end_x;
        public double y;
        public double height;
        public bool reverse;
    }
    public class CrescendoRenderOpts:NoteRenderOpts
    {
        public double extend_left;
        public double extend_right;
        public double y_shift;
        public static void Merge(NoteRenderOpts renderOptions,CrescendoRenderOpts crescendoRenderOpts)
        {
            CrescendoRenderOpts result = (CrescendoRenderOpts)renderOptions;
            //下面只做差额复制
            result.extend_left = crescendoRenderOpts.extend_left;
            result.extend_right = crescendoRenderOpts.extend_right;
            result.y_shift = crescendoRenderOpts.y_shift;
        }
    }
}
