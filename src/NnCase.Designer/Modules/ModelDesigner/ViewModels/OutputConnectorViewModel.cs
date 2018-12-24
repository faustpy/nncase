﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NnCase.Converter.Model;
using ReactiveUI;

namespace NnCase.Designer.Modules.ModelDesigner.ViewModels
{
    public class OutputConnectorViewModel : ReactiveObject
    {
        public OutputConnector Model { get; private set; }

        public string Name { get; }

        private readonly int[] _dimensions;

        public ReadOnlySpan<int> Dimensions => _dimensions;

        public string DimensionsText => $"{Dimensions[0]}x{Dimensions[1]}x{Dimensions[2]}x{Dimensions[3]}";

        public ILayerViewModel Owner { get; }

        private Point _position;
        public Point Position
        {
            get => _position;
            set
            {
                if (_position != value)
                {
                    _position = value;
                    this.RaisePropertyChanged();
                    PositionChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler PositionChanged;

        public OutputConnectorViewModel(string name, int[] dimensions, ILayerViewModel owner)
        {
            Name = name;
            Owner = owner;
            _dimensions = dimensions;
        }

        public void SetDimension(int index, int value)
        {
            _dimensions[index] = value;
            this.RaisePropertyChanged(nameof(Dimensions));
            this.RaisePropertyChanged(nameof(DimensionsText));
        }
    }
}