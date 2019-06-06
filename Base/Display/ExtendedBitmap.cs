using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Base.Display
{

    public class ExtendedBitmap : IDisposable, ICloneable
    {

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


        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }


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


        private ExtendedBitmap()
        {
            this.Cache = new ExtendedBitmap.PropertyCache();
            this._isNew = true;
            this._isInitialised = false;
        }


        public ExtendedBitmap(Size imageSize)
        {
            this.Cache = new ExtendedBitmap.PropertyCache
            {
                Size = imageSize
            };
            this.Initialise();
        }


        public ExtendedBitmap(int x, int y)
        {
            this.Cache = new ExtendedBitmap.PropertyCache
            {
                Size = new Size(x, y)
            };
            this.Initialise();
        }


        public ExtendedBitmap(string fileName)
        {
            this.Cache = new ExtendedBitmap.PropertyCache();
            this.Initialise(fileName);
        }


        private bool _isDisposed;


        private Bitmap _bits;


        private Graphics _surface;


        protected ExtendedBitmap.PropertyCache Cache;


        private bool _isNew;


        private bool _isInitialised;


        protected class PropertyCache
        {

            public void Update(ref Bitmap args)
            {
                this.Size = args.Size;
                this._location = new Point(0, 0);
                this.Bounds = new Rectangle(this._location, this.Size);
                this.BitDepth = args.PixelFormat;
            }


            public void Update(ref Graphics args)
            {
                if (this.Clip != null)
                {
                    this.Clip.Dispose();
                }
                this.Clip = args.Clip;
                this.ClipRect = ExtendedBitmap.PropertyCache.RectConvert(args.ClipBounds);
            }


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


            public Size Size;


            private Point _location;


            public Rectangle Bounds;


            public Region Clip;


            public Rectangle ClipRect;


            public PixelFormat BitDepth = PixelFormat.Format32bppArgb;
        }
    }
}
