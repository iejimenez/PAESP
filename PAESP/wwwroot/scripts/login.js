class LoginView {
    constructor() {

        this.getValidationConfig = this.getValidationConfig.bind(this);
        this.clickBtnLoginHandler = this.clickBtnLoginHandler.bind(this);
        this.postAutenticate = this.postAutenticate.bind(this);

        this._initHtml()
        this._initConstants()
        this._initEventBindings();
        this._init();

    }

    _initHtml() {
        this.$inputUsuario = $("#txtUsuario");
        this.$inputPassword = $("#txtPassword");
        this.$btnLogin = $("#btnLogin");
    }

    _initConstants() {
        this.API_LOGIN = '/Login/Autenticate'
        this.LOGIN_FORM = 'login-form'
    }

    _initEventBindings() {
        this.$btnLogin.on("click", this.clickBtnLoginHandler);
        $(`#${this.LOGIN_FORM} .change`).on("change", (event) => {
            inputChangeHandlerFunction.call(this, event);
        });
       /* $(`#${this.LOGIN_FORM}`).on("hide.bs.modal", this.cleanModal);*/
    }

    _init() {
        this.login = {};
        createValidation.call(this, this.LOGIN_FORM, this.getValidationConfig());
    }

    getValidationConfig() {
        const validationConfig = {
            user: {
                required: true
            },
            pass: {
                required: true
            }
        }
        return validationConfig;
    }


    async clickBtnLoginHandler() {
        if (this.formValidator[this.LOGIN_FORM].form()) {
            ShowLoading(true);
            const result = await this.postAutenticate();
            CloseLoading();
            if (!result.Is_Error) {
                window.location.href = '/Home/Index';
            } else {
                swal.fire({
                    title: "¡Error!",
                    text: result.Msj,
                    confirmButtonColor: "#66BB6A",
                    type: "error"
                });
            }

        }
    }


    postAutenticate() {
        //let formData = new FormData();
        //formData.append('login', JSON.stringify));
        return new Promise((resolve, reject) => {
            $.ajax({
                url: this.API_LOGIN,
                content: "application/json; charset=utf-8",
                type: "POST",
                dataType: "json",
                data: { "login": this.login },
                success: function (data) {
                    resolve(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    reject(new Error(`${errorThrown} - ${this.API_SAVE_Distributor}`));
                }
            });
        });
    }

}

export default LoginView;