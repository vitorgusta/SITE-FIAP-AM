create or replace package pkg_login is 

function criptografia (p_valor varchar) return raw;

function login (p_usuario go_pessoa.usuario%type,p_senha go_pessoa.senha%type) return boolean;

end;
/
create or replace package body pkg_login is 

  function criptografia (p_valor varchar) return raw is
  
  senha_cripto raw(32) := null;   
  begin 
  
    senha_cripto := rawtohex(dbms_obfuscation_toolkit.md5(input => utl_raw.cast_to_raw(p_valor)));
    return nvl(senha_cripto,'');   
  
  end criptografia;

  function login (p_usuario go_pessoa.usuario%type,p_senha go_pessoa.senha%type) return boolean is 
  
    v_senha_cripto raw := criptografia(p_senha);
    v_count_user number;
  
  begin 
  
    select count(1) 
    into v_count_user
    from go_pessoa
    where usuario = p_usuario
    and   senha = v_senha_cripto;
    
    
    if v_count_user = 0 then 
        
        return false;
        
    elsif v_count_user = 1 then 
         
        return true;
    
    else 
      
        Raise_Application_Error (-20343, 'Foi localizado mais de um cadastro com o mesmo usuario e senha.');
        
    end if;    
       
    
  end login;
  
  
end pkg_login;
/
