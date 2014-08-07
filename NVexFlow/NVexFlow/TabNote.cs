﻿//tabnote.js
using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    /// <summary>
    ///  ## Description
    //
    // The file implements notes for Tablature notation. This consists of one or
    // more fret positions, and can either be drawn with or without stems.
    //
    // See `tests/tabnote_tests.js` for usage examples
    /// </summary>
    public class TabNote:StemmableNote
    {
        #region js直译部分
        public TabNote(NoteStruct tabStruct,object drawStem)
            : base(tabStruct)
        { Init(tabStruct,drawStem); }
        /// <summary>
        /// Initialize the TabNote with a `tab_struct` full of properties and whether to `draw_stem` when rendering the note
        /// </summary>
        /// <param name="tabStruct"></param>
        /// <param name="drawStem"></param>
        private void Init(object tabStruct,object drawStem)
        {
            //          var superclass = Vex.Flow.TabNote.superclass;
            //superclass.init.call(this, tab_struct);

            //this.ghost = false; // Renders parenthesis around notes
            //// Note properties
            ////
            //// The fret positions in the note. An array of `{ str: X, fret: X }`
            //this.positions = tab_struct.positions;

            //// Render Options
            //Vex.Merge(this.render_options, {
            //  // font size for note heads and rests
            //  glyph_font_scale: 30,
            //  // Flag to draw a stem
            //  draw_stem: draw_stem,
            //  // Flag to draw dot modifiers
            //  draw_dots: draw_stem,
            //  // Flag to extend the main stem through the stave and fret positions
            //  draw_stem_through_stave: false
            //});

            //this.glyph =
            //  Vex.Flow.durationToGlyph(this.duration, this.noteType);
            //if (!this.glyph) {
            //  throw new Vex.RuntimeError("BadArguments",
            //      "Invalid note initialization data (No glyph found): " +
            //      JSON.stringify(tab_struct));
            //}

            //this.buildStem();
            //this.setStemDirection(Stem.UP);

            //// Renders parenthesis around notes
            //this.ghost = false;
            //this.updateWidth();
        }
        /// <summary>
        /// The ModifierContext category
        /// </summary>
        public override string Category
        {
            get
            {
                return "tabnotes";
            }
        }
        /// <summary>
        /// Set as ghost `TabNote`, surrounds the fret positions with parenthesis.Often used for indicating frets that are being bent to
        /// </summary>
        public bool Ghost
        {
            set
            {
                //类型是bool？
                this.ghost = value;
                UpdateWidth();
            }
        }
        /// <summary>
        /// Determine if the note has a stem
        /// </summary>
        /// <returns></returns>
        public new object HasStem()
        {
            //return this.render_options.draw_stem; 
            return null;
        }
        /// <summary>
        /// Get the default stem extension for the note
        /// </summary>
        /// <returns></returns>
        public int GetStemExtension()
        {
            //              var glyph = this.getGlyph();

            //if (this.stem_extension_override != null) {
            //  return this.stem_extension_override;
            //}

            //if (glyph) {
            //  return this.getStemDirection() === 1 ? glyph.tabnote_stem_up_extension :
            //    glyph.tabnote_stem_down_extension;
            //}

            //return 0;
            return 0;
        }
        /// <summary>
        /// Add a dot to the note
        /// </summary>
        /// <returns></returns>
        public object AddDot()
        {
            //var dot = new Vex.Flow.Dot();
            //this.dots++;
            //return this.addModifier(dot, 0);
            return null;
        }
        /// <summary>
        /// Calculate and store the width of the note
        /// </summary>
        public void UpdateWidth()
        {
            //          this.glyphs = [];
            //this.width = 0;
            //for (var i = 0; i < this.positions.length; ++i) {
            //  var fret = this.positions[i].fret;
            //  if (this.ghost) fret = "(" + fret + ")";
            //  var glyph = Vex.Flow.tabToGlyph(fret);
            //  this.glyphs.push(glyph);
            //  this.width = (glyph.width > this.width) ? glyph.width : this.width;
            //}
        }
        /// <summary>
        /// Set the `stave` to the note
        /// </summary>
        public override Stave Stave
        {
            set
            {
                //                  var superclass = Vex.Flow.TabNote.superclass;
                //superclass.setStave.call(this, stave);
                //this.context = stave.context;
                //this.width = 0;

                //// Calculate the fret number width based on font used
                //var i;
                //if (this.context) {
                //  for (i = 0; i < this.glyphs.length; ++i) {
                //    var text = "" + this.glyphs[i].text;
                //    if (text.toUpperCase() != "X")
                //      this.glyphs[i].width = this.context.measureText(text).width;
                //    this.width = (this.glyphs[i].width > this.width) ?
                //      this.glyphs[i].width : this.width;
                //  }
                //}

                //var ys = [];

                //// Setup y coordinates for score.
                //for (i = 0; i < this.positions.length; ++i) {
                //  var line = this.positions[i].str;
                //  ys.push(this.stave.getYForLine(line - 1));
                //}

                //return this.setYs(ys);
            }
        }
        /// <summary>
        /// Get the fret positions for the note
        /// </summary>
        public IList<object> Positions
        {
            //类型不明
            get
            { return this.positions; }
        }
        /// <summary>
        /// Add self to the provided modifier context `mc`
        /// </summary>
        /// <param name="mc"></param>
        public override void AddToModifierContext(ModifierContext mc)
        {
            //this.setModifierContext(mc);
            //for (var i = 0; i < this.modifiers.length; ++i)
            //{
            //    this.modifierContext.addModifier(this.modifiers[i]);
            //}
            //this.modifierContext.addModifier(this);
            //this.preFormatted = false;
            //return this;
        }
        /// <summary>
        /// Get the `x` coordinate to the right of the note
        /// </summary>
        /// <returns></returns>
        public double GetTieRightX()
        {
            //var tieStartX = this.getAbsoluteX();
            //var note_glyph_width = this.glyph.head_width;
            //tieStartX += (note_glyph_width / 2);
            //tieStartX += ((-this.width / 2) + this.width + 2);

            //return tieStartX;
            return 0;
        }
        /// <summary>
        /// Get the `x` coordinate to the left of the note
        /// </summary>
        /// <returns></returns>
        public double GetTieLeftX()
        {
            //var tieEndX = this.getAbsoluteX();
            //var note_glyph_width = this.glyph.head_width;
            //tieEndX += (note_glyph_width / 2);
            //tieEndX -= ((this.width / 2) + 2);

            //return tieEndX;
            return 0;
        }
        /// <summary>
        /// Get the default `x` and `y` coordinates for a modifier at a specific `position` at a fret position `index`
        /// </summary>
        /// <param name="position"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public object GetModifierStartXY(object position,int index)
        {
            //               if (!this.preFormatted) throw new Vex.RERR("UnformattedNote",
            //    "Can't call GetModifierStartXY on an unformatted note");

            //if (this.ys.length === 0) throw new Vex.RERR("NoYValues",
            //    "No Y-Values calculated for this note.");

            //var x = 0;
            //if (position == Vex.Flow.Modifier.Position.LEFT) {
            //  x = -1 * 2;  // extra_left_px
            //} else if (position == Vex.Flow.Modifier.Position.RIGHT) {
            //  x = this.width + 2; // extra_right_px
            //} else if (position == Vex.Flow.Modifier.Position.BELOW ||
            //           position == Vex.Flow.Modifier.Position.ABOVE) {
            //    var note_glyph_width = this.glyph.head_width;
            //    x = note_glyph_width / 2;
            //}

            //return {x: this.getAbsoluteX() + x, y: this.ys[index]};
            return null;
        }
        /// <summary>
        /// Get the default line for rest
        /// </summary>
        /// <returns></returns>
        public string GetLineForRest()
        {
            //return this.positions[0].str; 
            return "";
        }
        /// <summary>
        /// Pre-render formatting
        /// </summary>
        public override void PreFormat()
        {
            //if (this.preFormatted) return;
            //if (this.modifierContext) this.modifierContext.preFormat();
            //// width is already set during init()
            //this.setPreFormatted(true);
        }
        /// <summary>
        /// Get the x position for the stem
        /// </summary>
        /// <returns></returns>
        public double GetStemX()
        {
            // return this.getCenterGlyphX(); 
            return 0;
        }
        /// <summary>
        /// Get the y position for the stem
        /// </summary>
        /// <returns></returns>
        public double GetStemY()
        {
            //              var num_lines = this.stave.getNumLines();

            //// The decimal staff line amounts provide optimal spacing between the
            //// fret number and the stem
            //var stemUpLine = -0.5;
            //var stemDownLine = num_lines - 0.5;
            //var stemStartLine = Stem.UP === this.stem_direction ? stemUpLine : stemDownLine;

            //return this.stave.getYForLine(stemStartLine);
            return 0;
        }
        /// <summary>
        /// Get the stem extents for the tabnote
        /// </summary>
        /// <returns></returns>
        public object GetStemExtents()
        {
            //              var stem_base_y = this.getStemY();
            //var stem_top_y = stem_base_y + (Stem.HEIGHT * -this.stem_direction);

            //return { topY: stem_top_y , baseY: stem_base_y};
            return null;
        }
        /// <summary>
        /// Draw the fal onto the context
        /// </summary>
        public void DrawFlag()
        {
            //var render_stem = this.beam == null && this.render_options.draw_stem;
            //var render_flag = this.beam == null && render_stem;

            //// Now it's the flag's turn.
            //if (this.glyph.flag && render_flag)
            //{
            //    var flag_x = this.getStemX() + 1;
            //    var flag_y = this.getStemY() - (this.stem.getHeight());
            //    var flag_code;

            //    if (this.stem_direction == Stem.DOWN)
            //    {
            //        // Down stems have flags on the left.
            //        flag_code = this.glyph.code_flag_downstem;
            //    }
            //    else
            //    {
            //        // Up stems have flags on the left.
            //        flag_code = this.glyph.code_flag_upstem;
            //    }

            //    // Draw the Flag
            //    Vex.Flow.renderGlyph(this.context, flag_x, flag_y,
            //        this.render_options.glyph_font_scale, flag_code);
            //}
        }
        /// <summary>
        /// Render the modifiers onto the context
        /// </summary>
        public void DrawModifiers()
        {
            //          // Draw the modifiers
            //this.modifiers.forEach(function(modifier) {
            //  // Only draw the dots if enabled
            //  if (modifier.getCategory() === 'dots' && !this.render_options.draw_dots) return;

            //  modifier.setContext(this.context);
            //  modifier.draw();
            //}, this);
        }
        /// <summary>
        /// Render the stem extension through the fret positions
        /// </summary>
        public void DrawStemThrough()
        {
            //          var stem_x = this.getStemX();
            //var stem_y = this.getStemY();
            //var ctx = this.context;

            //var stem_through = this.render_options.draw_stem_through_stave;
            //var draw_stem = this.render_options.draw_stem;
            //if (draw_stem && stem_through) {
            //  var total_lines = this.stave.getNumLines();
            //  var strings_used = this.positions.map(function(position) {
            //    return position.str;
            //  });

            //  var unused_strings = getUnusedStringGroups(total_lines, strings_used);
            //  var stem_lines = getPartialStemLines(stem_y, unused_strings,
            //                        this.getStave(), this.getStemDirection());

            //  // Fine tune x position to match default stem
            //  if (!this.beam || this.getStemDirection() === 1) {
            //    stem_x += (Stem.WIDTH / 2);
            //  }

            //  ctx.save();
            //  ctx.setLineWidth(Stem.WIDTH);
            //  stem_lines.forEach(function(bounds) {
            //    ctx.beginPath();
            //    ctx.moveTo(stem_x, bounds[0]);
            //    ctx.lineTo(stem_x, bounds[bounds.length - 1]);
            //    ctx.stroke();
            //    ctx.closePath();
            //  });
            //  ctx.restore();
            //}
        }
        /// <summary>
        /// Render the fret positions onto the context
        /// </summary>
        public void DrawPositions()
        {
            //var ctx = this.context;
            //var x = this.getAbsoluteX();
            //var ys = this.ys;
            //var y;

            //for (var i = 0; i < this.positions.length; ++i)
            //{
            //    y = ys[i];

            //    var glyph = this.glyphs[i];

            //    // Center the fret text beneath the notation note head
            //    var note_glyph_width = this.glyph.head_width;
            //    var tab_x = x + (note_glyph_width / 2) - (glyph.width / 2);

            //    ctx.clearRect(tab_x - 2, y - 3, glyph.width + 4, 6);

            //    if (glyph.code)
            //    {
            //        Vex.Flow.renderGlyph(ctx, tab_x, y + 5 + glyph.shift_y,
            //            this.render_options.glyph_font_scale, glyph.code);
            //    }
            //    else
            //    {
            //        var text = glyph.text.toString();
            //        ctx.fillText(text, tab_x, y + 5);
            //    }
            //}
        }
        /// <summary>
        /// The main rendering function for the entire note
        /// </summary>
        public void Draw()
        {
            //             if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //      "Can't draw without a canvas context.");
            //  if (!this.stave) throw new Vex.RERR("NoStave", "Can't draw without a stave.");
            //  if (this.ys.length === 0) throw new Vex.RERR("NoYValues",
            //      "Can't draw note without Y values.");

            //  var render_stem = this.beam == null && this.render_options.draw_stem;

            //  this.drawPositions();
            //  this.drawStemThrough();

            //  var stem_x = this.getStemX();
            //  var stem_y = this.getStemY();
            //  if (render_stem) {
            //    this.drawStem({
            //      x_begin: stem_x,
            //      x_end: stem_x,
            //      y_top: stem_y,
            //      y_bottom: stem_y,
            //      y_extend: 0,
            //      stem_extension: this.getStemExtension(),
            //      stem_direction: this.stem_direction
            //    });
            //  }

            //  this.drawFlag();
            //  this.drawModifiers();
            //}
        }

        // ## Private Helpers
        //
        /// <summary>
        /// Gets the unused strings grouped together if consecutive.
        //
        // Parameters:
        // * num_lines - The number of lines
        // * strings_used - An array of numbers representing which strings have fret positions
        /// </summary>
        /// <param name="num_lines"></param>
        /// <param name="strings_used"></param>
        /// <returns></returns>
        private object GetUnusedStringGroups(int num_lines,object strings_used)
        {
            //                var stem_through = [];
            //var group = [];
            //for (var string = 1; string <= num_lines ; string++) {
            //  var is_used = strings_used.indexOf(string) > -1;

            //  if (!is_used) {
            //    group.push(string);
            //  } else {
            //    stem_through.push(group);
            //    group = [];
            //  }
            //}
            //if (group.length > 0) stem_through.push(group);

            //return stem_through;
            return null;
        }
        /// <summary>
        /// Gets groups of points that outline the partial stem lines between fret positions
        // 
        // Parameters:
        // * stem_Y - The `y` coordinate the stem is located on
        // * unused_strings - An array of groups of unused strings
        // * stave - The stave to use for reference
        // * stem_direction - The direction of the stem
        /// </summary>
        /// <param name="stem_y"></param>
        /// <param name="unused_strings"></param>
        /// <param name="stave"></param>
        /// <param name="stem_direction"></param>
        /// <returns></returns>
        private object GetPartialStemLines(double stem_y,object unused_strings,object stave,object stem_direction)
        {
            //                var up_stem = stem_direction !== 1;
            //var down_stem = stem_direction !== -1;

            //var line_spacing = stave.getSpacingBetweenLines();
            //var total_lines = stave.getNumLines();

            //var stem_lines = [];

            //unused_strings.forEach(function(strings) {
            //  var containsLastString = strings.indexOf(total_lines) > -1;
            //  var containsFirstString =  strings.indexOf(1) > -1;

            //  if ((up_stem && containsFirstString) ||
            //     (down_stem && containsLastString)) {
            //    return;
            //  }

            //  // If there's only one string in the group, push a duplicate value.
            //  // We do this because we need 2 strings to convert into upper/lower y
            //  // values.
            //  if (strings.length === 1) {
            //    strings.push(strings[0]);
            //  }

            //  var line_ys = [];
            //  // Iterate through each group string and store it's y position
            //  strings.forEach(function(string, index, strings) {
            //    var isTopBound = string === 1;
            //    var isBottomBound = string === total_lines;

            //    // Get the y value for the appropriate staff line,
            //    // we adjust for a 0 index array, since string numbers are index 1
            //    var y = stave.getYForLine(string - 1);

            //    // Unless the string is the first or last, add padding to each side
            //    // of the line
            //    if (index === 0 && !isTopBound) {
            //      y -= line_spacing/2 - 1;
            //    } else if (index === strings.length - 1 && !isBottomBound){
            //      y += line_spacing/2 - 1;
            //    }

            //    // Store the y value
            //    line_ys.push(y);

            //    // Store a subsequent y value connecting this group to the main
            //    // stem above/below the stave if it's the top/bottom string
            //    if (stem_direction === 1 && isTopBound) {
            //      line_ys.push(stem_y - 2);
            //    } else if (stem_direction === -1 && isBottomBound) {
            //      line_ys.push(stem_y + 2);
            //    }
            //  });

            //  // Add the sorted y values to the
            //  stem_lines.push(line_ys.sort(function(a, b) {
            //    return a - b;
            //  }));
            //});

            //return stem_lines;
            return null;
        }
        #endregion



        #region 隐含字段
        bool ghost;
        IList<object> positions;
        object glyph;
        #endregion



    }
}
