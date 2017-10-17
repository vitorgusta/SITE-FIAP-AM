create or replace procedure prc_insere_auditoria(p_tabela go_auditoria.tabela%type,p_alteracao go_auditoria.tipo_alteracao%type,p_historico go_auditoria.historico%type,p_usuario go_auditoria.usuario%type) is 


begin 

  insert into go_auditoria (id
                           ,tabela
                           ,tipo_alteracao
                           ,historico
                           ,data
                           ,usuario) values (seq_auditoria.nextval
                                            ,p_tabela
                                            ,p_alteracao
                                            ,p_historico
                                            ,sysdate
                                            ,p_usuario);
 
end prc_insere_auditoria;
/


