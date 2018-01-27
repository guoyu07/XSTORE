function system_alert(message) {
    layer.open({
        title: ['系统提示', 'background-color:#F60; color:#fff;'],
        content: message,
        btn: 'OK'
    });
}