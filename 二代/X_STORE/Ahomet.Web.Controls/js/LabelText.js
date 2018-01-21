function Label_copyTextToHiddenField(source, destination) {
    ///将Label控件的的值赋给隐藏控件
    document.getElementById(destination).value = document.getElementById(source).innerHTML;
}