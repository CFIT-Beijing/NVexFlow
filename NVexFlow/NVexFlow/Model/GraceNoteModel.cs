namespace NVexFlow.Model
{
    public class GraceNoteStruct:StaveNoteStruct
    {
        public bool slash;
    }

    public class GraceNoteRenderOpts:StaveNoteRenderOpts
    {
        public double stem_height;
    }
}
