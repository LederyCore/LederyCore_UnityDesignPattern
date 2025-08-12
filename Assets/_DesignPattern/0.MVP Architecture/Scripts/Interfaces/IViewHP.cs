
namespace MVP_Architecture
{
    /// <summary>
    /// Interface for the HP View in MVP pattern.
    /// Defines methods for updating HP text and slider.
    /// MVP 패턴에서 HP View 인터페이스. HP 텍스트와 슬라이더 업데이트 메서드를 정의.
    /// </summary>
    public interface IViewHP
    {
        public void UpdateHPText(int hp);

        public void UpdateHPSlider(float hpPercentage);
    }
}
