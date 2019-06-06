using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Base.Display
{
    // Token: 0x0200000D RID: 13
    public class ExtendedBitmap : IDisposable, ICloneable
    {
        // Token: 0x170001F4 RID: 500
        // (get) Token: 0x0600045E RID: 1118 RVA: 0x00013920 File Offset: 0x00011B20
        public Graphics Graphics
        {
            get
            {
                Graphics graphics;
                if (this._isInitialised)
                {
                    this._isNew = false;
                    graphics = this._surface;
                }
                else if (this.Initialise())
                {
                    this._isNew = false;
                    graphics = this._surface;
                }
                else
                {
                    graphics = null;
                }
                return graphics;
            }
        }

        // Token: 0x170001F5 RID: 501
        // (get) Token: 0x0600045F RID: 1119 RVA: 0x00013978 File Offset: 0x00011B78
        public Bitmap Bitmap
        {
            get
            {
                Bitmap result;
                if (this._isInitialised)
                {
                    result = this._bits;
                }
                else if (!this.Initialise())
                {
                    result = null;
                }
                else
                {
                    result = this._bits;
                }
                return result;
            }
        }

        // Token: 0x170001F6 RID: 502
        // (get) Token: 0x06000460 RID: 1120 RVA: 0x000139BC File Offset: 0x00011BBC
        private bool CanInitialise
        {
            get
            {
                bool flag;
                if (this._isDisposed)
                {
                    flag = false;
                }
                else if (this.Cache.Size.Width > 0 & this.Cache.Size.Height > 0)
                {
                    flag = true;
                }
                else if (this.Cache.Bounds.Width > 0 & this.Cache.Bounds.Height > 0)
                {
                    this.Cache.Size.Width = this.Cache.Bounds.Width;
                    this.Cache.Size.Height = this.Cache.Bounds.Height;
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                return flag;
            }
        }

        // Token: 0x170001F7 RID: 503
        // (get) Token: 0x06000461 RID: 1121 RVA: 0x00013A94 File Offset: 0x00011C94
        // (set) Token: 0x06000462 RID: 1122 RVA: 0x00013ACC File Offset: 0x00011CCC
        public Size Size
        {
            get
            {
                Size result;
                if (!this._isInitialised)
                {
                    result = default(Size);
                }
                else
                {
                    result = this.Cache.Size;
                }
                return result;
            }
            set
            {
                if (value.Width != this.Cache.Size.Width || value.Height != this.Cache.Size.Height)
                {
                    this.Cache.Size = value;
                    this.Initialise();
                }
            }
        }

        // Token: 0x170001F8 RID: 504
        // (get) Token: 0x06000463 RID: 1123 RVA: 0x00013B2C File Offset: 0x00011D2C
        // (set) Token: 0x06000464 RID: 1124 RVA: 0x00013B64 File Offset: 0x00011D64
        private Region Clip
        {
            get
            {
                Region result;
                if (!this._isInitialised)
                {
                    result = new Region();
                }
                else
                {
                    result = this.Cache.Clip;
                }
                return result;
            }
            set
            {
                if (this._isInitialised)
                {
                    this._surface.Clip = value;
                    this.Cache.Update(ref this._surface);
                    this._isNew = false;
                }
            }
        }

        // Token: 0x170001F9 RID: 505
        // (get) Token: 0x06000465 RID: 1125 RVA: 0x00013BA8 File Offset: 0x00011DA8
        public Rectangle ClipRect
        {
            get
            {
                Rectangle result;
                if (!this._isInitialised)
                {
                    result = default(Rectangle);
                }
                else
                {
                    result = this.Cache.ClipRect;
                }
                return result;
            }
        }

        // Token: 0x06000466 RID: 1126 RVA: 0x00013BDF File Offset: 0x00011DDF
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Token: 0x06000467 RID: 1127 RVA: 0x00013BF4 File Offset: 0x00011DF4
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!this._isDisposed)
                {
                    this._isNew = false;
                    this._isInitialised = false;
                    if (this._surface != null)
                    {
                        this._surface.Dispose();
                    }
                    if (this._bits != null)
                    {
                        this._bits.Dispose();
                    }
                    if (this.Cache.Clip != null)
                    {
                        this.Cache.Clip.Dispose();
                    }
                    this._isDisposed = true;
                }
            }
        }

        // Token: 0x06000468 RID: 1128 RVA: 0x00013C88 File Offset: 0x00011E88
        public object Clone()
        {
            object obj;
            if (!this._isInitialised)
            {
                obj = new ExtendedBitmap();
            }
            else
            {
                ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.Size)
                {
                    Cache = this.Cache
                };
                extendedBitmap._surface.DrawImageUnscaled(this._bits, new Point(0, 0));
                extendedBitmap.Clip = this.Clip;
                extendedBitmap._isInitialised = this._isInitialised;
                extendedBitmap._isNew = this._isNew;
                obj = extendedBitmap;
            }
            return obj;
        }

        // Token: 0x06000469 RID: 1129 RVA: 0x00013D10 File Offset: 0x00011F10
        private bool Initialise()
        {
            bool flag;
            if (!this.CanInitialise)
            {
                flag = false;
            }
            else
            {
                if (this._surface != null)
                {
                    this._surface.Dispose();
                }
                if (this._bits != null)
                {
                    this._bits.Dispose();
                }
                this._bits = new Bitmap(this.Cache.Size.Width, this.Cache.Size.Height, this.Cache.BitDepth);
                this._surface = Graphics.FromImage(this._bits);
                this.Cache.Update(ref this._bits);
                this._surface.Clip = new Region(this.Cache.Bounds);
                this.Cache.Update(ref this._surface);
                this._isNew = true;
                this._isInitialised = true;
                flag = true;
            }
            return flag;
        }

        // Token: 0x0600046A RID: 1130 RVA: 0x00013E08 File Offset: 0x00012008
        private void Initialise(string fileName)
        {
            if (this._surface != null)
            {
                this._surface.Dispose();
            }
            if (this._bits != null)
            {
                this._bits.Dispose();
            }
            if (!File.Exists(fileName))
            {
                this.Cache = new ExtendedBitmap.PropertyCache
                {
                    Size = new Size(32, 32)
                };
                this.Initialise();
            }
            else
            {
                this._bits = new Bitmap(fileName);
                this._surface = Graphics.FromImage(this._bits);
                this.Cache.Update(ref this._bits);
                this._surface.Clip = new Region(this.Cache.Bounds);
                this.Cache.Update(ref this._surface);
                this._isNew = true;
                this._isInitialised = true;
            }
        }

        // Token: 0x0600046B RID: 1131 RVA: 0x00013EEA File Offset: 0x000120EA
        private ExtendedBitmap()
        {
            this.Cache = new ExtendedBitmap.PropertyCache();
            this._isNew = true;
            this._isInitialised = false;
        }

        // Token: 0x0600046C RID: 1132 RVA: 0x00013F10 File Offset: 0x00012110
        public ExtendedBitmap(Size imageSize)
        {
            this.Cache = new ExtendedBitmap.PropertyCache
            {
                Size = imageSize
            };
            this.Initialise();
        }

        // Token: 0x0600046D RID: 1133 RVA: 0x00013F44 File Offset: 0x00012144
        public ExtendedBitmap(int x, int y)
        {
            this.Cache = new ExtendedBitmap.PropertyCache
            {
                Size = new Size(x, y)
            };
            this.Initialise();
        }

        // Token: 0x0600046E RID: 1134 RVA: 0x00013F7B File Offset: 0x0001217B
        public ExtendedBitmap(string fileName)
        {
            this.Cache = new ExtendedBitmap.PropertyCache();
            this.Initialise(fileName);
        }

        // Token: 0x0400011E RID: 286
        private bool _isDisposed;

        // Token: 0x0400011F RID: 287
        private Bitmap _bits;

        // Token: 0x04000120 RID: 288
        private Graphics _surface;

        // Token: 0x04000121 RID: 289
        protected ExtendedBitmap.PropertyCache Cache;

        // Token: 0x04000122 RID: 290
        private bool _isNew;

        // Token: 0x04000123 RID: 291
        private bool _isInitialised;

        // Token: 0x0200000E RID: 14
        protected class PropertyCache
        {
            // Token: 0x0600046F RID: 1135 RVA: 0x00013F9C File Offset: 0x0001219C
            public void Update(ref Bitmap args)
            {
                this.Size = args.Size;
                this._location = new Point(0, 0);
                this.Bounds = new Rectangle(this._location, this.Size);
                this.BitDepth = args.PixelFormat;
            }

            // Token: 0x06000470 RID: 1136 RVA: 0x00013FE8 File Offset: 0x000121E8
            public void Update(ref Graphics args)
            {
                if (this.Clip != null)
                {
                    this.Clip.Dispose();
                }
                this.Clip = args.Clip;
                this.ClipRect = ExtendedBitmap.PropertyCache.RectConvert(args.ClipBounds);
            }

            // Token: 0x06000471 RID: 1137 RVA: 0x00014030 File Offset: 0x00012230
            private static Rectangle RectConvert(RectangleF iRect)
            {
                int x;
                if (iRect.X > 2.14748365E+09f)
                {
                    x = int.MaxValue;
                }
                else if (iRect.X < -2.14748365E+09f)
                {
                    x = int.MinValue;
                }
                else
                {
                    x = Convert.ToInt32(iRect.X);
                }
                int y;
                if (iRect.Y > 2.14748365E+09f)
                {
                    y = int.MaxValue;
                }
                else if (iRect.Y < -2.14748365E+09f)
                {
                    y = int.MinValue;
                }
                else
                {
                    y = Convert.ToInt32(iRect.Y);
                }
                int width;
                if (iRect.Width > 2.14748365E+09f)
                {
                    width = int.MaxValue;
                }
                else if (iRect.Width < -2.14748365E+09f)
                {
                    width = int.MinValue;
                }
                else
                {
                    width = Convert.ToInt32(iRect.Width);
                }
                int height;
                if (iRect.Height > 2.14748365E+09f)
                {
                    height = int.MaxValue;
                }
                else if (iRect.Height < -2.14748365E+09f)
                {
                    height = int.MinValue;
                }
                else
                {
                    height = Convert.ToInt32(iRect.Height);
                }
                return new Rectangle(x, y, width, height);
            }

            // Token: 0x04000124 RID: 292
            public Size Size;

            // Token: 0x04000125 RID: 293
            private Point _location;

            // Token: 0x04000126 RID: 294
            public Rectangle Bounds;

            // Token: 0x04000127 RID: 295
            public Region Clip;

            // Token: 0x04000128 RID: 296
            public Rectangle ClipRect;

            // Token: 0x04000129 RID: 297
            public PixelFormat BitDepth = PixelFormat.Format32bppArgb;
        }
    }
}
