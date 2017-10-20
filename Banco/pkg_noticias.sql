create or replace package pkg_noticias is

  procedure prc_insere   (p_titulo go_noticias.titulo%type,p_materia go_noticias.materia%type,p_imagem go_noticias.imagem%type,p_sta_ativo go_noticias.sta_ativo%type,p_id_categoria go_noticias.go_categoria_id%type);

  procedure prc_atualiza (p_id go_noticias.id%type,p_titulo go_noticias.titulo%type,p_materia go_noticias.materia%type,p_imagem go_noticias.imagem%type,p_sta_ativo go_noticias.sta_ativo%type,p_id_categoria go_categoria.id%type,p_usuario go_pessoa.usuario%type);

  procedure prc_deleta   (p_id_noticias go_noticias.id%type, p_usuario go_pessoa.usuario%type);
  
end pkg_noticias;
/
create or replace package body pkg_noticias is 

  procedure prc_insere (p_titulo go_noticias.titulo%type,p_materia go_noticias.materia%type,p_imagem go_noticias.imagem%type,p_sta_ativo go_noticias.sta_ativo%type,p_id_categoria go_noticias.go_categoria_id%type) is 
  
  begin
  
    if p_titulo is not null and p_materia is not null and p_sta_ativo is not null then 
    
      insert into go_noticias (id
                              ,titulo
                              ,materia
                              ,imagem
                              ,data_materia
                              ,sta_ativo
                              ,go_categoria_id) values(seq_noticias.nextval
                                                   ,p_titulo
                                                   ,p_materia
                                                   ,p_imagem
                                                   ,sysdate
                                                   ,p_sta_ativo
                                                   ,p_id_categoria);  
      commit;
      
    else 
        
        Raise_Application_Error (-20343, 'Favor preencher todas as informaçoes obrigatorias');
    
    end if;

    exception when others then 
	      rollback;
	      Raise_Application_Error (SQLERROR, 'Ocorreu um erro');
   

  end prc_insere;
  
  procedure prc_atualiza (p_id go_noticias.id%type,p_titulo go_noticias.titulo%type,p_materia go_noticias.materia%type,p_imagem go_noticias.imagem%type,p_sta_ativo go_noticias.sta_ativo%type,p_id_categoria go_categoria.id%type,p_usuario go_pessoa.usuario%type) IS 
  
  v_linha_antiga go_noticias%rowtype;
  v_historico    varchar2(4000);
  v_categoria_antiga go_categoria.categoria%type;
  
  begin
  
    if p_titulo is not null and p_materia is not null and p_sta_ativo is not null then 
      
      select *
      into v_linha_antiga
      from go_noticias
      where id = p_id;
    
      if v_linha_antiga.titulo != p_titulo then 
         
         v_historico := 'Titulo Antigo: '||p_titulo||chr(13);
      
      end if;
      
      if v_linha_antiga.materia != p_materia then 
         
         v_historico := v_historico||'Materia Antiga: '||p_materia||chr(13);
      
      end if;
      
     
      if v_linha_antiga.sta_ativo != p_sta_ativo then 
         
         if p_sta_ativo = 'S' then 
         
            v_historico := v_historico||'Materia ativada '||chr(13);
            
         end if;
         
         if p_sta_ativo = 'N' then 
         
            v_historico := v_historico||'Materia desativada '||chr(13);
            
         end if;
         
      end if;
      
      if v_linha_antiga.go_categoria_id != p_id_categoria then 
         begin
          select categoria
          into v_categoria_antiga
          from go_categoria
          where id = v_linha_antiga.go_categoria_id;
        exception when no_data_found then 
                       Raise_Application_Error (-20343, 'Categoria antiga nao encontrada, favor verificar o cadastro');
                  when too_many_rows then 
                       Raise_Application_Error (-20343, 'Categoria antiga duplicada, favor verificar o cadastro');
        end; 
        
         v_historico := v_historico||'Categoria antiga: '||v_categoria_antiga;
      
      end if;
      
      update go_noticias 
      set titulo = p_titulo
      ,   materia = p_materia
      ,   imagem = p_imagem
      ,   sta_ativo = p_sta_ativo
      ,   go_categoria_id = p_id_categoria
      where id = p_id;
            
      commit;

      prc_insere_auditoria('GO_NOTICIAS','UPDATE',v_historico,p_usuario);
      
     
    else 
        
        Raise_Application_Error (-20343, 'Favor preencher todas as informaçoes obrigatorias');
    
    end if;
  exception when others then 
	      rollback;
	      Raise_Application_Error (SQLERROR, 'Ocorreu um erro');
  end prc_atualiza;
  
  
  procedure prc_deleta   (p_id_noticias go_noticias.id%type, p_usuario go_pessoa.usuario%type) is 
  
  begin 
  
    delete go_noticias
    where id = p_id_noticias;
    
    prc_insere_auditoria('GO_NOTICIAS','DELETE',null,p_usuario);
    
    commit;
    
    exception when others then 
	      rollback;
	      Raise_Application_Error (SQLERROR, 'Ocorreu um erro');
  end prc_deleta;
  
end pkg_noticias;
/
