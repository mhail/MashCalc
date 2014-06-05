using System;

namespace MashCalc
{
	public class MashWaterViewModel : BaseViewModel
	{
		private float _grainBill = 10;
		public float GrainBill {
			get { return _grainBill; }
			set {
				base.SetProperty (ref _grainBill, value);
				CalcStrikeTemp ();
			}
		}

		private float _boilTime = 60;
		public float BoilTime {
			get { return _boilTime; }
			set {
				base.SetProperty (ref _boilTime, value);
				CalcStrikeTemp ();
			}
		}

		private float _mashThickness = 1.25f;

		public float MashThickness {
			get { return _mashThickness; }
			set {
				base.SetProperty (ref _mashThickness, value);
				CalcStrikeTemp ();
			}
		}

		private float _targetMashTemp = 155;
		public float TargetMashTemp {
			get { return _targetMashTemp; }
			set {
				base.SetProperty (ref _targetMashTemp, value);
				CalcStrikeTemp ();
			}
		}

		private float _sparageTemp = 170;
		public float SparageTemp {
			get { return _sparageTemp; }
			set {
				base.SetProperty (ref _sparageTemp, value);
				CalcStrikeTemp ();
			}
		}

		private float _grainTemp = 72;
		public float GrainTemp {
			get { return _grainTemp; }
			set {
				base.SetProperty (ref _grainTemp, value);
				CalcStrikeTemp ();
			}
		}

		private float _strikeTemp;
		public float StrikeTemp {
			get { return _strikeTemp; }
			set {
				base.SetProperty (ref _strikeTemp, value);
			}
		}

		private float _strikeSize;
		public float StrikeSize {
			get { return _strikeSize; }
			set {
				base.SetProperty (ref _strikeSize, value);
			}
		}

		protected virtual void CalcStrikeTemp()
		{
			StrikeTemp = (0.2f / MashThickness) * (TargetMashTemp - GrainTemp) + TargetMashTemp;
			var strikeSizeinQt = GrainBill * MashThickness;
			StrikeSize = strikeSizeinQt / 4;

			MashOutSize = (SparageTemp - TargetMashTemp) * (0.2f * GrainBill + strikeSizeinQt) / (210 - StrikeTemp) /4;

			SparageSize = ((GrainBill * MashThickness * 1.5f) /4)  - MashOutSize;

			var totalH2o = StrikeSize + MashOutSize + SparageSize;
			var boilVolume = totalH2o - (GrainBill * 0.125f); // Absorbsion Loss

			BatchSize = boilVolume - (boilVolume * (BoilTime / 60 * 0.1F)); 
		}

		private float _mashOutSize;
		public float MashOutSize {
			get { return _mashOutSize; }
			set {
				base.SetProperty (ref _mashOutSize, value);
			}
		}

		private float _sparageSize;
		public float SparageSize {
			get { return _sparageSize; }
			set {
				base.SetProperty (ref _sparageSize, value);
			}
		}

		private float _batchSize;
		public float BatchSize {
			get { return _batchSize; }
			set {
				base.SetProperty (ref _batchSize, value);
			}
		}
	}
}

