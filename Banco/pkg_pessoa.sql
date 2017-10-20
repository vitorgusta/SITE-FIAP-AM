create or replace package pkg_pessoa is 

  procedure 	;
  
  procedure envia_pergunta(p_mensagem go_contato.mensagem%type, p_id_usario go_pessoa.id%type);
  
end pkg_pessoa;
/
create or replace package body pkg_pessoa is 

  procedure prc_insere(p_nome go_pessoa.nome_completo%type,p_end go_pessoa.endereco%type,p_email go_pessoa.email%type, p_data_nascimento go_pessoa.data_nascimento%type, p_usuario go_pessoa.usuario%type, p_senha go_pessoa.senha%type) is 
    
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
       commit;

    
    else 
    
      Raise_Application_Error (-20343, 'Favor preencher todas as informaçoes obrigatorias');
    
    end if;
  exception when others then 
	      rollback;
	      Raise_Application_Error (SQLERROR, 'Ocorreu um erro');
  
  end prc_insere;
  procedure envia_pergunta (p_mensagem go_contato.mensagem%type, p_id_usario go_pessoa.id%type) is
  
  begin 
  
    if p_mensagem is not null then 
    
      insert into go_contato(id
                            ,dt_mensagem
                            ,mensagem
                            ,go_pessoa_id) values (seq_pessoa.nextval
                                                  ,sysdate
                                                  ,p_mensagem
                                                  ,p_id_usario);
      commit;
    
    else 
    
      Raise_Application_Error (-20343, 'Favor preencher enviar a mensagem');
    
    end if;
  
  exception when others then 
	      rollback;
	      Raise_Application_Error (SQLERROR, 'Ocorreu um erro');
  end;
  
end pkg_pessoa;
/

