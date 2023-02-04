﻿using Bit.BlazorUI;
using IToolKit.API.Enums.Tools.EncodersDecoders;
using IToolKit.API.Tools.EncodersDecoders;

namespace IToolKit.Pages.Tools.EncodersDecoders.Base64TextEncoderDecoder
{
    public partial class Base64TextEncoderDecoder
    {
        EncodeDecodeTypeEnum _EncodeDecodeType;
        string _CurrentValue;
        string _Result;
        bool _IsAutoUpdate = true;

        private void OnHashTypeChange(BitDropDownItem hashType)
        {
            if (Enum.TryParse(hashType.Value, true, out EncodeDecodeTypeEnum type))
            {
                _EncodeDecodeType = type;
            }

            OnChangeEvent(_CurrentValue);
        }

        private void OnChangeEvent(string value)
        {
            _CurrentValue = value;

            if (String.IsNullOrWhiteSpace(value) || !_IsAutoUpdate)
                return;

            Calc(value);
        }

        void Calc(string value)
        {
            try
            {
                switch (_EncodeDecodeType)
                {
                    case EncodeDecodeTypeEnum.Encode:
                        _Result = EncoderDecoderTools.Base64Encode(value);
                        break;
                    case EncodeDecodeTypeEnum.Decode:
                        _Result = EncoderDecoderTools.Base64Decode(value);
                        break;
                    default:
                        _Result = "Type not found!";
                        break;
                }
            }
            catch (Exception)
            {
                _Result = String.Empty;
            }
        }

        private List<BitDropDownItem> GetEncodeDecodes()
        {
            return new()
            {
                new BitDropDownItem()
                {
                    ItemType = BitDropDownItemType.Normal,
                    Text = "Encode",
                    Value = "Encode"
                },
                new BitDropDownItem()
                {
                    ItemType = BitDropDownItemType.Normal,
                    Text = "Decode",
                    Value = "Decode"
                },
            };
        }
    }
}
