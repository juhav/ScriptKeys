namespace ScriptKeys.Helpers
{
    public class ListItem<T>
    {
        private string text = "";
        private T value;

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value ?? "";
            }
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public ListItem(string text, T value)
        {
            this.text = text;
            this.value = value;
        }

        public override string ToString()
        {
            return this.text;
        }

    }

}
