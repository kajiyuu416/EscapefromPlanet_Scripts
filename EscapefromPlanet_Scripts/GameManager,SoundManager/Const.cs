using System.Collections.ObjectModel;
using System;

//�萔�N���X�A���N���X����̎Q��
namespace Const
{
    public static class CO
    {
        public static readonly ReadOnlyCollection<float> const_Float_List =
                    Array.AsReadOnly(new float[] { 1.0f, 2.0f, 3.0f,4.0f,5,0f});
        public static readonly ReadOnlyCollection<int> const_Int_List =
            Array.AsReadOnly(new int[] { 1, 2, 3, 4, 5});

    }

}