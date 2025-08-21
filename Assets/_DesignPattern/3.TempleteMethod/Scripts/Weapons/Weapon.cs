namespace Templete_Methods
{
    using UnityEngine;
    using Utill;

    /// <summary>
    /// ���ø� �޼��带 ������ ���� Ŭ�����Դϴ�.
    /// ���� ���ϰ� ������ ���� �ֽ��ϴ�.
    /// </summary>
    public abstract class Weapon
    {

        #region Methods
        /// <summary>
        /// ���ø� �޼ҵ� ������ �⺻ ������ �����մϴ�.
        /// </summary>
        public void Attack()
        {
            Aim(); // ���� �ܰ�
            Fire(); // ���⺰�� ������ ���� �ܰ�
            AfterFire(); // ���� �� ������ �ܰ�
        }

        protected virtual void Aim()
        {
            Utill.Log("�⺻ ����");
        }

        protected abstract void Fire(); // ���⿡ ���� �޶����� ������ �����մϴ�.

        protected virtual void AfterFire()
        {
            Utill.Log("���� �� ������");
        }
        #endregion
    }
}