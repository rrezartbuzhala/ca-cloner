def read_config(config_key):
    file = open(".config", "r")
    file_text = file.read()
    config_key_index = file_text.index(config_key)
    equal_sign_index = file_text.index("=",config_key_index)
    semicolon_sign_index = file_text.index(";",equal_sign_index)
    config_value = file_text[equal_sign_index+1:semicolon_sign_index]
    return config_value