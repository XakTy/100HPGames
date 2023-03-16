using System;

namespace Core
{
	public class StatValue
	{
		private float _value;
		public float Value
		{
			get
			{
				return _value;
			}

			set
			{
				_value = value;
				OnValueChanged?.Invoke();
			}
		}

		public event Action OnValueChanged;

		public StatValue(float value)
		{
			Value = value;
		}
	}
}