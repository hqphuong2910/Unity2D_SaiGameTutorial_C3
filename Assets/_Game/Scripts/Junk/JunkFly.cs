namespace _Game.Scripts.Junk
{
    public class JunkFly : ParentFly
    {
        protected override void ResetValue()
        {
            base.ResetValue();

            flySpeed = 1f;
        }
    }
}