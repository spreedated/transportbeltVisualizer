using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using TransportbeltRender.Models;

namespace TransportbeltRender
{
    public class TransportImage : IDisposable
    {
        internal Image renderResult;
        private bool disposedValue;

        public int ImageWidth { get; init; }
        public int ImageHeight { get; init; }
        public TransportImageProperties Properties { get; init; }
        public TransportImageRenderElements Elements { get; init; }

        #region Constructor
        public TransportImage(int imageWidth, int imageHeight, TransportImageProperties properties, TransportImageRenderElements elements)
        {
            if (imageWidth == default || imageWidth <= -1)
            {
                throw new ArgumentException("Width cannot be null or less", nameof(imageWidth));
            }

            if (imageHeight == default || imageHeight <= -1)
            {
                throw new ArgumentException("Height cannot be null or less", nameof(imageHeight));
            }

            this.ImageWidth = imageWidth;
            this.ImageHeight = imageHeight;
            this.Properties = properties;
            this.Properties ??= new();
            this.Elements = elements;
            this.Elements ??= new();
        }
        #endregion

        /// <summary>
        /// Routine to render the image
        /// </summary>
        /// <returns></returns>
        public async Task Render()
        {
            this.renderResult?.Dispose();

            Image image = new Image<Rgba32>(this.ImageWidth, this.ImageHeight, this.Properties.DrawBackground ? this.Properties.BackgroundColor : Color.Transparent);

            await Task.Run(() =>
            {
                this.RenderTransportBand(image);
                this.RenderScanner(image);
                this.RenderCrates(image);
                this.RenderPallets(image);
            });

            this.renderResult = image;
        }

        private void RenderTransportBand(Image image)
        {
            float tPosX = 0;

            for (int i = 0; i < this.Elements.TransportBandSegments; i++)
            {
                RectangularPolygon bandRect = new(tPosX, this.Properties.BandYLocation, this.Properties.BandWitdh, image.Height - this.Properties.BandYLocation);
                image.Mutate(x => x.Fill(Color.FromRgb(0, 0, 0), bandRect));
                RectangularPolygon bandRectInside = new(tPosX + this.Properties.BandStroke, this.Properties.BandYLocation + this.Properties.BandStroke, this.Properties.BandWitdh - (this.Properties.BandStroke * 2), (image.Height - this.Properties.BandYLocation) - this.Properties.BandStroke);
                image.Mutate(x => x.Fill(Color.FromRgb(255, 255, 255), bandRectInside));

                tPosX += this.Properties.BandWitdh;
            }
        }

        private void RenderScanner(Image image)
        {
            if (this.Elements.ScannerPosition >= 0)
            {
                RectangularPolygon bandRect = new((this.Properties.BandWitdh * this.Elements.ScannerPosition) + ((this.Properties.BandWitdh / 2) - (this.Properties.ScannerWidth / 2)), this.Properties.BandYLocation + this.Properties.BandStroke + 2, this.Properties.ScannerWidth, 8);

                if (this.Elements.ScannerPosition == 0)
                {
                    bandRect = new((this.Properties.BandWitdh - (this.Properties.BandWitdh / 2)) - (this.Properties.ScannerWidth / 2), this.Properties.BandYLocation + this.Properties.BandStroke + 2, this.Properties.ScannerWidth, 8);
                }

                image.Mutate(x => x.Fill(this.Properties.ScannerColor, bandRect));

                EllipsePolygon scannerCircleDL = new(bandRect.Location.X + 3, bandRect.Location.Y + bandRect.Height, 3);
                image.Mutate(x => x.Fill(this.Properties.ScannerColor, scannerCircleDL));

                EllipsePolygon scannerCircleDR = new(bandRect.Location.X + (bandRect.Width - 3), bandRect.Location.Y + bandRect.Height, 3);
                image.Mutate(x => x.Fill(this.Properties.ScannerColor, scannerCircleDR));

                RectangularPolygon scannerRectHandle = new(bandRect.Location.X + (bandRect.Width / 2) - (4 / 2), bandRect.Location.Y + 6, 4, 12);
                image.Mutate(x => x.Fill(this.Properties.ScannerColor, scannerRectHandle));

                EllipsePolygon scannerCircleHandle = new(bandRect.Location.X + (bandRect.Width / 2), bandRect.Location.Y + bandRect.Height + 10, 2.0f);
                image.Mutate(x => x.Fill(this.Properties.ScannerColor, scannerCircleHandle));

                RectangularPolygon scannerRectDisplay = new(bandRect.Location.X + (bandRect.Width / 2) - 2, bandRect.Location.Y, 4, 4);
                image.Mutate(x => x.Fill(Color.FromRgb(220, 220, 220), scannerRectDisplay));
            }
        }

        private void RenderCrates(Image image)
        {
            foreach (int bandId in this.Elements.CrateOnSegments)
            {
                this.RenderCrate(image, new(this.Properties.BandWitdh * bandId, this.Properties.BandYLocation - 8), this.Properties.BandWitdh);
            }
        }

        private void RenderPallets(Image image)
        {
            foreach (KeyValuePair<int, int> crateOnPallet in this.Elements.CratesOnPallets)
            {
                this.RenderPallet(image, new(crateOnPallet.Key * this.Properties.BandWitdh, this.Properties.BandYLocation), this.Properties.BandWitdh);

                float crateYPosition = this.Properties.BandYLocation - 12;
                for (int i = 0; i < crateOnPallet.Value; i++)
                {
                    this.RenderCrate(image, new(this.Properties.BandWitdh * crateOnPallet.Key, crateYPosition), this.Properties.BandWitdh);
                    crateYPosition -= 8;
                }
            }
        }

        private void RenderCrate(Image image, Vector2 location, float width, float crateHeight = 8, float handleHeight = 2)
        {
            RectangularPolygon crateRectStroke = new(location.X, location.Y, width, crateHeight);
            image.Mutate(x => x.Fill(Color.FromRgb(30, 30, 30), crateRectStroke));

            RectangularPolygon crateRectInner = new(location.X + 2, location.Y, width - 4, crateHeight - 2);
            image.Mutate(x => x.Fill(this.Properties.CrateColor, crateRectInner));

            RectangularPolygon crateRectHandle = new(location.X + ((width / 2) - (width / 6)), location.Y, width / 3, handleHeight);
            image.Mutate(x => x.Fill(Color.FromRgb(255, 255, 255), crateRectHandle));
        }

        private void RenderPallet(Image image, Vector2 location, float width, float palletHeight = 4)
        {
            RectangularPolygon crateRectBackground = new(location.X, location.Y - palletHeight, width, palletHeight);
            image.Mutate(x => x.Fill(this.Properties.PalletColor, crateRectBackground));

            RectangularPolygon crateRectBar0 = new(location.X + ((width / 4) - 3), location.Y - palletHeight, 2, palletHeight);
            image.Mutate(x => x.Fill(Color.FromRgb(240, 240, 240), crateRectBar0));

            RectangularPolygon crateRectBar1 = new(location.X + ((width / 4) + 5), location.Y - palletHeight, 2, palletHeight);
            image.Mutate(x => x.Fill(Color.FromRgb(240, 240, 240), crateRectBar1));

            RectangularPolygon crateRectBar2 = new(location.X + ((width / 4) + 13), location.Y - palletHeight, 2, palletHeight);
            image.Mutate(x => x.Fill(Color.FromRgb(240, 240, 240), crateRectBar2));
        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.renderResult?.Dispose();
                }

                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
