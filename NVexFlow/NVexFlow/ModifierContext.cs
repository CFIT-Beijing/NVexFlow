﻿using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public class ModifierContext
    {
        double width;

        public double Width
        {
            get
            { return width; }
        }



        public ModifierContextState state;//Note直接使用了state字段

        bool preFormatted;

        public static void ShiftRestVertical(object rest,object note,object dir)
        { }


        public static void CenterRest(object rest,object noteU,object noteL)
        { }

        IList<object> modifiers;

        public ModifierContext()
        { }

        public ModifierContext AddModifier(Modifier modifier)
        {
            return null;
        }

        public IList<Modifier> GetModifiers(string type)
        { return null; }


        public double GetExtraLeftPx()
        { return this.state.left_shift; }

        public double GetExtraRightPx()
        { return this.state.right_shift; }

        public object GetMetrics()
        {
            return null;
        }

        public ModifierContext FormatNotes()
        {
            return null;
        }


        public ModifierContext FormatNotesByY(IList<object> notes)
        {
            return null;
        }

        public ModifierContext FormatDots()
        {
            return null;
        }


        public ModifierContext FormatAccidentals()
        {
            return null;
        }


        public ModifierContext FormatAccidentalsByY(IList<object> accList)
        {
            return null;
        }


        public ModifierContext FormatStrokes()
        {
            return null;
        }


        public ModifierContext FormatFretHandFingers()
        {
            return null;
        }


        public ModifierContext FormatBends()
        {
            return null;
        }


        public ModifierContext FormatVibratos()
        {
            return null;
        }


        public ModifierContext FormatAnnotations()
        {
            return null;
        }


        public ModifierContext FormatArticulations()
        {
            return null;
        }


        public ModifierContext FormatGraceNoteGroups()
        {
            return null;
        }


        public object PostFormatNotes()
        {
            return null;
        }

        public void PreFormat()
        { }


        public ModifierContext PostFormat()
        {
            return null;
        }
    }
}
