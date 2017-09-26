create or replace package pkg_pessoa is 

  procedure prc_insere(p_nome varchar2,p_end varchar2,p_email varchar2, p_data_nascimento date, p_usuario varchar2, p_senha varchar2);
  
  procedure envia_pergunta(p_mensagem varchar2, p_id_usario varchar2);
  
end pkg_pessoa;
/
create or replace package body pkg_pessoa is 

  procedure prc_insere(p_nome varchar2,p_end varchar2,p_email varchar2, p_data_nascimento date, p_usuario varchar2, p_senha varchar2);
    
    v_senha_criptografa raw := pkg_login.criptografia(p_senha);
    
  begin 
  
    if  p_nome is not null and p_end is not null and p_data_nascimento is not null and p_usuario is not null and v_senha_criptografa is not null then 
    
      insert into go_pessoa(id
                          ,nome_completo
                          ,endereco
                          ,email
                          ,data_nascimento
                          ,usuario
                          ,senha) values (seq_pessoa.nextval
                                          ,p_nome
                                          ,p_end
                                          ,p_email
                                          ,p_data_nascimento
                                          ,p_usuario
                                          ,v_senha_criptografa);
    
    else 
    
      Raise_Application_Error (-20343, 'Favor preencher todas as informaçoes obrigatorias');
    
    end if;
    
  
  end prc_insere;
  procedure envia_pergunta (p_mensagem varchar2, p_id_usario varchar2) is
  
  begin 
  
    if p_mensagem is not null then 
    
      insert into go_contato(id
                            ,dt_mensagem
                            ,mensagem
                            ,go_pessoa_id) values (seq_pessoa.nextval
                                                  ,sysdate
                                                  ,p_mensagem
                                                  ,p_id_usario);
    
    else 
    
      Raise_Application_Error (-20343, 'Favor preencher enviar a mensagem');
    
    end if;
  
  end;
  
end pkg_pessoa;
/

