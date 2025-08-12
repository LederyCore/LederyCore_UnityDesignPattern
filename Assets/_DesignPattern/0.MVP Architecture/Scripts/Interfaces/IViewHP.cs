
namespace MVP_Architecture
{
    /// <summary>
    /// Interface for the HP View in MVP pattern.
    /// Defines methods for updating HP text and slider.
    /// MVP ���Ͽ��� HP View �������̽�. HP �ؽ�Ʈ�� �����̴� ������Ʈ �޼��带 ����.
    /// </summary>
    public interface IViewHP
    {
        public void UpdateHPText(int hp);

        public void UpdateHPSlider(float hpPercentage);
    }
}
